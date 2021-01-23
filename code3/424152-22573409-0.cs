    IList<Dictionary<string, object>> bookmarks = SimpleBookmark.GetBookmark(pdfReader);
    foreach (Dictionary<string, object> bk in bookmarks)
    {
    string bjj = bk.Values.ToArray().GetValue(0).ToString();
    }
