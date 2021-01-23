         public  List<int> ReadPdfFile(string fileName, String searthText)
                {
                    List<int> pages = new List<int>();
                    if (File.Exists(fileName))
                    {
                        PdfReader pdfReader = new PdfReader(fileName);
                        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                        {
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                            string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                            if (currentPageText.Contains(searthText))
                            {
                                pages.Add(page);
                            }
                        }
                        pdfReader.Close();
                    }
                    return pages;
                }
