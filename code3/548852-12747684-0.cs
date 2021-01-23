    using System;
    using iTextSharp.text.pdf;
    using System.IO;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                int PgCount = 0;
                string[] PdfFiles = Directory.GetFiles(@"C:\Saurabh\", "*.pdf");
                Console.WriteLine("{0} PDF Files in directory", PdfFiles.Length.ToString());
                for (int i = 0; i < PdfFiles.Length; i++)
                {
                    PgCount = GetNumberOfPages(PdfFiles[i]);
                    Console.WriteLine("{0} File has {1} pages", PdfFiles[i], PgCount.ToString());
                }
                Console.ReadLine();
            }
    
            static int GetNumberOfPages(String FilePath)
            {
                PdfReader pdfReader = new PdfReader(FilePath); 
                return pdfReader.NumberOfPages; 
            }
        }
    }
