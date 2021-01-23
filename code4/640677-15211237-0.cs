    using (MemoryStream mem = new MemoryStream())
    {
        mem.Write(documentByteArray, 0, (int)documentByteArray.Length);
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
        {
            string docText = null;
            using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
            {
                docText = sr.ReadToEnd();
            }
            Regex regexText = new Regex("Hello world!");
            docText = regexText.Replace(docText, "Hi Everyone!");
            using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
            {
                sw.Write(docText);
            }
        }
    }
