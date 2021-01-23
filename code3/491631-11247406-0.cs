    public Stream packageStream() {
        var ms = new MemoryStream();
        var wrdPk = WordprocessingDocument.Create(ms, WordprocessingDocumentType.Document);
        // Build the package ...
        var docPart = wrdPk.AddMainDocumentPart();
        docPart.Document = new Document(
            new Body(new Paragraph(new Run(new Text("Hello world.")))));
        // Flush all changes
        wrdPk.Close();
        return ms;
    }
