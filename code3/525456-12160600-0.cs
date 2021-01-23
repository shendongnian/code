    byte[] byteArray = File.ReadAllBytes("C:\\temp\\test.docx");
    using (MemoryStream stream = new MemoryStream())
    {
        stream.Write(byteArray, 0, (int)byteArray.Length);
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
        {
           // Do work here
        }
        File.WriteAllBytes("C:\\temp\\test.docx", stream.ToArray()); 
    }
