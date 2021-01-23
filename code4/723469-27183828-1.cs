       using System.Text.RegularExpressions;
       using iTextSharp.text.pdf;
       using iTextSharp.text.pdf.parser;
       using iTextSharp.text;
       //Call this method in main with parameter
        public static void MergePages(string outputPdfPath, string[] lstFiles)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, 
            new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
            sourceDocument.Open();
            try
            {
                for (int f = 0; f < lstFiles.Length - 1; f++)
                {
                    int pages = 1; 
                    reader = new PdfReader(lstFiles[f]);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }
                    reader.Close();
                }
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
