    public void ProcessRequest(HttpContext context)
    {
        using (MemoryStream mem = new MemoryStream())
        {
            // Create Document
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(mem, WordprocessingDocumentType.Document, true))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text("Hello world!"));
                mainPart.Document.Save();
            }
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=HelloWorld.docx");
            mem.Seek(0, SeekOrigin.Begin);
            mem.CopyTo(context.Response.OutputStream);
            context.Response.Flush();
            context.Response.End();
        }
    }
