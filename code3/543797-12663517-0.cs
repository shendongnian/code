    using (WordprocessingDocument newDoc = WordprocessingDocument.Open(@"c:\temp\external_img.docx", true))
    {
        var run = new Run();
        var picture = new Picture();
        
        var shape = new Shape() { Id = "_x0000_i1025", Style = "width:453.5pt;height:270.8pt" };
        var imageData = new ImageData() { RelationshipId = "rId56" };
        shape.Append(imageData);
        picture.Append(shape);
        run.Append(picture);
        var paragraph = newdoc.MainDocumentPart.Document.Body.Elements<Paragraph>().FirstOrDefault();
        paragraph.Append(run);      
        newDoc.MainDocumentPart.AddExternalRelationship(
           "http://schemas.openxmlformats.org/officeDocument/2006/relationships/image",
           new System.Uri("<url to your picture>", System.UriKind.Absolute), "rId56");
    }
