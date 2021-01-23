    string Filepath = @"C:\Users\infinity\Desktop\zoyeb.docx";
    using (var wordprocessingDocument = WordprocessingDocument.Create(Filepath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
    {
        MainDocumentPart mainPart = wordprocessingDocument.AddMainDocumentPart();
        mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
        Body body = mainPart.Document.AppendChild(new Body());
        DocumentFormat.OpenXml.Wordprocessing.Paragraph para = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
        DocumentFormat.OpenXml.Wordprocessing.Run run = para.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
        run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("siddiq"));
        wordprocessingDocument.MainDocumentPart.Document.Save();
    }
