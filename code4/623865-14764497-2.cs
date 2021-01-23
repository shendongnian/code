    object oViews = nd.Views;
    object[] oarrViews = (object[])oViews;
    Dictionary<string, List<string>> folderDict = new Dictionary<string, List<string>>();
    for (int x=0; x < oarrViews.Length - 1; x++)
    {
        NotesView view = viewArray[x];
        if (view.IsFolder) 
        {
            NotesDocument doc = view.GetFirstDocument();
            while (doc != null)
            {
                // Populate folderDict Dictionary by setting
                // document's UNID as Key, and adding folder name to List
            }
        }
    }
