                    using (WordprocessingDocument doc = WordprocessingDocument.Open(destination, true))
                    {
                        var mainDocPart = doc.MainDocumentPart;
                        if (doc == null) {
                            mainDocPart = doc.AddMainDocumentPart();
                        }
                        if (mainDocPart.Document == null)
                        {
                            mainDocPart.Document = new Document();
                        }
                        
                        ApplyHeader(doc);
                        ApplyFooter(doc);
                    }
