    List<int> bookmarks = new List<int>();
    while(true)
    {
        try
        {
            Line next = scintilla1.Markers.FindNextMarker();
            scintilla1.Caret.Position = next.StartPosition;
            scintilla1.Caret.Goto(next.EndPosition);
            scintilla1.Scrolling.ScrollToCaret();
            scintilla1.Focus();
            bookmarks.Add(next.Number);
        }
        catch(Exception ex)
        {
            break;
        }
    }
    
    string Marks="";
    for(int i =0;i<bookmarks.Count;i++)
        Marks += bookmarks[i]+ ",";
