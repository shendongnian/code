    // Create a new empty document.
    DocumentModel document = new DocumentModel();
    
    // Add document content.
    document.Sections.Add(new Section(document, new Paragraph(document, "Hello World!")));
    
    // Microsoft Packaging API cannot write directly to Response.OutputStream.
    // Therefore we use temporary MemoryStream.
    using (MemoryStream documentStream = new MemoryStream())
    {
    	document.Save(documentStream, SaveOptions.DocxDefault);
    
    	// Stream file to browser.
    	Response.Clear();
    	Response.ContentType = "application/vnd.openxmlformats";
    	Response.AddHeader("Content-Disposition", "attachment; filename=Document.docx");
    
    	documentStream.WriteTo(Response.OutputStream);
    
    	Response.End();
    }
