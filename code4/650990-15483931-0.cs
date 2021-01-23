    HashMap<int> bookmarks = new HashMap<int>();
    for (int i = 0; i < scintilla1.Lines.Count; i++)
    {
        bookmarks.Add(scintilla1.Markers.FindNextMarker(i).Number);
    }
    foreach (var bookmark in bookmarks)
    {
        MessageBox.Show(bookmark.ToString());
    }
