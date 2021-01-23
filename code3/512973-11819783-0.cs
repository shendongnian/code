    using (WordprocessingDocument doc = WordprocessingDocument.Open(destFileName, true))
                        {
                            
                            Run run = new Run();
                            RunProperties runProperties = new RunProperties();
    
                            runProperties.AppendChild<Underline>(new Underline() { Val = DocumentFormat.OpenXml.Wordprocessing.UnderlineValues.Single });
                            runProperties.AppendChild<Bold>(new Bold());
                            run.AppendChild<RunProperties>(runProperties);
                            run.AppendChild(new Text("test"));
    
                            //Note: I had to create a paragraph element to place the run into.
                            Paragraph p = new Paragraph();
                            p.AppendChild(run);
                            doc.MainDocumentPart.Document.Body.AppendChild(p);
                        }
