    List<int> pagesToReplace = new List<int>();
    PdfImageCollection pagesToEncode = new PdfImageCollection();
    using (Document doc = new Document(sourceStream, password)) {
        for (int i=0; i < doc.Pages.Count; i++) {
            Page page = doc.Pages[i];
            if (page.SingleImageOnly) {
                pagesToReplace.Add(i);
                // a PDF image encapsulates an image an compression parameters
                PdfImage image = ProcessImage(sourceStream, doc, page, i);
                pagesToEncode.Add(i);
            }
        }
        PdfEncoder encoder = new PdfEncoder();
        encoder.Save(tempOutStream, pagesToEncode, null); // re-encoded pages
        tempOutStream.Seek(0, SeekOrigin.Begin);
        sourceStream.Seek(0, SeekOrigin.Begin);
        PdfDocument finalDoc = new PdfDocument(sourceStream, password);
        PdfDocument replacementPages = new PdfDocument(tempOutStream);
        for (int i=0; i < pagesToReplace.Count; i++) {
             finalDoc.Pages[pagesToReplace[i]] = replacementPages.Pages[i];
        }
        finalDoc.Save(finalOutputStream);
