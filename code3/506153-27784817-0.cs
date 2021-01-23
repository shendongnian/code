    public static void Join(params string[] filepaths)
        {
         //filepaths = new[] { "D:\\one.docx", "D:\\two.docx", "D:\\three.docx", "D:\\four.docx", "D:\\five.docx" };
            if (filepaths != null && filepaths.Length > 1)
            
                using (WordprocessingDocument myDoc = WordprocessingDocument.Open(@filepaths[0], true))
                {
                    MainDocumentPart mainPart = myDoc.MainDocumentPart;
                    for (int i = 1; i < filepaths.Length; i++)
                    {
                        string altChunkId = "AltChunkId" + i;
                        AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(
                            AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        using (FileStream fileStream = File.Open(@filepaths[i], FileMode.Open))
                        {
                            chunk.FeedData(fileStream);
                        }
                        DocumentFormat.OpenXml.Wordprocessing.AltChunk altChunk = new DocumentFormat.OpenXml.Wordprocessing.AltChunk();
                        altChunk.Id = altChunkId;
                        //new page, if you like it...
                            mainPart.Document.Body.AppendChild(new Paragraph(new Run(new Break() { Type = BreakValues.Page })));
                        //next document
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<Paragraph>().Last());
                    }
                    mainPart.Document.Save();
                    myDoc.Close();
                }
        }
