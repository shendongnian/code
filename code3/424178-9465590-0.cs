    public bool isBookmarked(string pdfSourceFile, int pageNumber)
    {
        var reader = new PdfReader(pdfSourceFile, new System.Text.ASCIIEncoding().GetBytes(""));
        var bookmarks = SimpleBookmark.GetBookmark(reader);
        foreach (var bookmark in bookmarks)
            if (Int32.Parse(bookmark["Page"].ToString().Split(' ')[0]) == pageNumber)
                return true;
        return false;
    }
