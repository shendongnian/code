    using PdfSharp.Pdf;
    using (PdfDocument document = PdfReader.IO.Open("bookmarked.pdf", IO.PdfDocumentOpenMode.Import))
    {
        PdfDictionary outline = (PdfDictionary)document.Internals.Catalog.Elements.GetObject("/Outlines");
        PrintBookmark(outline);
    }
    void PrintBookmark(PdfDictionary bookmark)
    {
        Console.WriteLine(bookmark.Elements.GetString("/Title"));
        for (PdfDictionary child = bookmark.Elements.GetObject("/First"); child != null; child = child.Elements.GetObject("/Next"))
        {
            PrintBookmark(child);
        }
    }
