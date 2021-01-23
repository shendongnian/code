    void OnNewFilenameAdded(string filename)
    {
        var item = new MenuItem();
        item.Command = _OpenFileCommand;
        item.Header  = filename;
        item.CommandParameter = filename;
        MenuItem_OpenRecent.Items.Insert(0, item);
    
        if (MenuItem_OpenRecent.Items.Count == 6)
            MenuItem_OpenRecent.Items.RemoveAt(5);
    }
