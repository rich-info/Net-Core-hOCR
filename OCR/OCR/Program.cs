using System;
using System.IO;
using Tesseract;

namespace OCR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start recognition");

            string imagePath = "C://OCR/testocr.png";
            string dataPath = "C://OCR//tessdata-304";
            string hOcrOutputPath = "C://OCR/output.html";

            try
            {
                // create the Tesseract OCR engine and set German (deu) as language
                TesseractEngine tesEngine = new TesseractEngine(
                    dataPath, 
                    "deu", 
                    EngineMode.Default);
                tesEngine.DefaultPageSegMode = PageSegMode.SingleColumn;
                
                // load the image with text
                Pix pic = Pix.LoadFromFile(imagePath);
                
                // process the image with Tesseract OCR engine
                Page page = tesEngine.Process(pic);
                // get the content as plain text.
                string text = page.GetText();
                Console.WriteLine(text);
                // get the formatted representation of the content (layout, style and text)
                string formattedText = page.GetHOCRText(0);
                // save the formatted text as a HTML file.
                File.WriteAllText(hOcrOutputPath, formattedText);
                
            }
            catch (Exception e)
            {
                // Exception handling
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}
