    var bookmarkStart = doc.Body.Descendants<BookmarkStart>().Where(r => r.Name == "tableBookmark");
    if (bookmarkStart != null)
    {
        var test  = bookmarkStart.First().Parent.Parent.Parent.Parent;
        if (test.GetType() == typeof (DocumentFormat.OpenXml.Wordprocessing.Table))
            myTable = (Table)test;
    }
