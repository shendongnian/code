    using (MemoryStream documentStream = new MemoryStream())
    {
        using (WordprocessingDocument myDoc = WordprocessingDocument.Create(documentStream, WordprocessingDocumentType.Document, true))
        {
            // Add a new main document part. 
            MainDocumentPart mainPart = myDoc.AddMainDocumentPart();
            //Create Document tree for simple document. 
            mainPart.Document = new Document();
            //Create Body (this element contains
            //other elements that we want to include 
            Body body = new Body();
            //Create paragraph 
            Paragraph paragraph = new Paragraph();
            Run run_paragraph = new Run();
            // we want to put that text into the output document 
            Text text_paragraph = new Text("Hello World!");
            //Append elements appropriately. 
            run_paragraph.Append(text_paragraph);
            paragraph.Append(run_paragraph);
            body.Append(paragraph);
            mainPart.Document.Append(body);
            
            // Save changes to the main document part. 
            mainPart.Document.Save();
            myDoc.Close();
            context.Response.ClearContent();
            context.Response.ClearHeaders();
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            SetContentType(context.Request, context.Response, "Simple.docx");
            documentStream.Seek(0, SeekOrigin.Begin);
            documentStream.CopyTo(context.Response.OutputStream);
            context.Response.Flush();
            context.Response.End();
        }
    }
