    using PdfSharp.Pdf;
    using (PdfDocument document = PdfReader.IO.Open("bookmarked.pdf", IO.PdfDocumentOpenMode.Import))
    {
        PdfDictionary outline = document.Internals.Catalog.Elements.GetDictionary("/Outlines");
        PrintBookmark(outline);
    }
    void PrintBookmark(PdfDictionary bookmark)
    {
        Console.WriteLine(bookmark.Elements.GetString("/Title"));
        for (PdfDictionary child = bookmark.Elements.GetDictionary("/First"); child != null; child = child.Elements.GetDictionary("/Next"))
        {
            PrintBookmark(child);
        }
    }
