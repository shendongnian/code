    public FileResult Download()
    {
        var urls = new List<string>
        { // Populate list with urls
            "C:\\1.html",
            "C:\\2.html"
        };
    
        var documents = new List<EO.Pdf.PdfDocument>();
        foreach(var url in urls)
        {
            var doc = new EO.Pdf.PdfDocument();
            EO.Pdf.HtmlToPdf.ConvertUrl(url, doc);
            documents.Add(doc);
        }
        
        EO.Pdf.PdfDocument mergedDocument = EO.Pdf.PdfDocument.Merge(documents.ToArray());
    
        var ms = new MemoryStream();
        mergedDocument.Save(ms);
        ms.Position = 0;
    
        return new FileStreamResult(ms, "application/pdf") { FileDownloadName = "download.pdf" };
    }
