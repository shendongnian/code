    var viewArray = nd.Views;
    var folderDict = new Dictionary<string, List<string>>();
    for (int x=1; x < viewArray.Length; x++)
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
