    foreach (Bookmark bookMark in oWordDoc.Bookmarks)
    {
        string bmName = bookMark.Name;
        Range bmRange = bookMark.Range;
        string bmText = bmRange.Text;
    }
