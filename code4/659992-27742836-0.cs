        public void ExtractTextFromPdf(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();
                ITextExtractionStrategy Strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string page = "";
               
                    page = PdfTextExtractor.GetTextFromPage(reader, i,Strategy);
                    string[] lines = page.Split('\n');
                    foreach (string line in lines)
                    {
                        MessageBox.Show(line);
                    }
                }
            }
        }
