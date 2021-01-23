    public void WalkBookmarks(Stream pdf)
    {
        // open the doc
        PdfDocument doc = new PdfDocument(pdf);
        if (doc.BookmarkTree != null)
        {
             // walk the list of top level bookmarks
             WalkBookmarks(doc.BookmarkTree.Bookmarks, 0);
        }
    }
    public void WalkBookmarks(PdfBookmarkList list, int depth)
    {
        if (list == null) return;
        foreach (PdfBookmark bookmark in list)
        {
            // indent to the depth of the list and write the Text
            // you can also get the color, basic font styling and
            // the action associated with the bookmark
            for (i = 0; i < depth; i++) Console.Write("  ");
            Console.Writeline(bookmark.Text);
            // recurse on any children
            WalkBookmarks(bookmark.Children, depth + 1);
        }
    }
