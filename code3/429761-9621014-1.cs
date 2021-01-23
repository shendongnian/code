            string html = @"<img src=""Untitled-1.png"" />";
            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "HtmlTest.pdf");
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
                using (Document doc = new Document(PageSize.A4, 50, 50, 80, 100)) {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                        doc.Open();
                        using (StringReader sr = new StringReader(html)) {
                            System.Collections.Generic.Dictionary<string, object> providers = new System.Collections.Generic.Dictionary<string, object>();
                            providers.Add(HTMLWorker.IMG_PROVIDER, new ImageThing(doc));
                            var parsedHtmlElements = HTMLWorker.ParseToList(sr, null,  providers);
                            foreach (var htmlElement in parsedHtmlElements) {
                                doc.Add(htmlElement as IElement);
                            }
                        }
                        doc.Close();
                    }
                }
            }
