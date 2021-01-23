    using System;
    using System.Text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    namespace PDFApp2
    {
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Your said path\the file name.pdf";
            string outPath = @"the output said path\the text file name.txt";
            int pagesToScan = 2;
            string strText = string.Empty;
            try
            {
                PdfReader reader = new PdfReader(filePath);
                
                for (int page = 1; page <= pagesToScan; page ++) //(int page = 1; page <= reader.NumberOfPages; page++) <- for scanning all the pages in A PDF
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                    strText = PdfTextExtractor.GetTextFromPage(reader, page, its);
                    
                    strText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(strText)));
                    //creating the string array and storing the PDF line by line
                    string[] lines = strText.Split('\n');
                    foreach (string line in lines)
                    {
                        //Creating and appending to a text file
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(outPath, true))
                        {
                            file.WriteLine(line);
                        }
                    }
                }
               
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
    }
