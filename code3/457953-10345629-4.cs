        using DocumentFormat.OpenXml.Packaging;
        using DocumentFormat.OpenXml.Wordprocessing;
        ....
        public byte[] OpenAndCombine(List<string> FileNames)
        {
            List<byte[]> documents = new List<byte[]>();
            foreach (string _FileName in FileNames)               
                    documents.Add(File.ReadAllBytes(_FileName));
            
            MemoryStream mainStream = new MemoryStream();
            mainStream.Write(documents[0], 0, documents[0].Length);
            mainStream.Position = 0;
            int pointer = 1;
            byte[] ret;
                using (WordprocessingDocument mainDocument = WordprocessingDocument.Open(mainStream, true))
                {
                    XElement newBody = XElement.Parse(mainDocument.MainDocumentPart.Document.Body.OuterXml);
                    for (pointer = 1; pointer < documents.Count; pointer++)
                    {
                        WordprocessingDocument tempDocument = WordprocessingDocument.Open(new MemoryStream(documents[pointer]), true);
                        XElement tempBody = XElement.Parse(tempDocument.MainDocumentPart.Document.Body.OuterXml);
                        newBody.Add(tempBody);
                        mainDocument.MainDocumentPart.Document.Body = new Body(newBody.ToString());
                        mainDocument.MainDocumentPart.Document.Save();
                        mainDocument.Package.Flush();
                    }
                }
                ret = mainStream.ToArray();
                mainStream.Close();
                mainStream.Dispose();
            return (ret);
        }
