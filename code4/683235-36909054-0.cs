    using (PdfReader reader = new PdfReader(path))
                {
                    StringBuilder text = new StringBuilder();
                    StringBuilder textfinal = new StringBuilder();
                    String page = "";
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        page = PdfTextExtractor.GetTextFromPage(reader, i);
                        string[] lines = page.Split('\n');
                        foreach (string line in lines)
                        {
                            string[] words = line.Split('\n');
                            foreach (string wrd in words)
                            {
                                
                            }
                            textfinal.Append(line);
                            textfinal.Append(Environment.NewLine); 
                        }
                        page = "";
                    }
               }
