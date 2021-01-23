    using (ClientContext spClientContext = new ClientContext("http://whatever"))
    {
        var rootweb = spClientContext.Web;
        FolderCollection folderCollection =
            rootweb.GetFolderByServerRelativeUrl("/Shared Documents/test2").Folders;
        // Don't just load the folder collection, but the property on each folder too
        spClientContext.Load(folderCollection, fs => fs.Include(f => f.ListItemAllFields));
        // Actually fetch the data
        spClientContext.ExecuteQuery();
        foreach (Folder folder in folderCollection)
        {
            // This property is now populated
            var item = folder.ListItemAllFields;
            // This is where the dates you want are stored
            var created = (DateTime)item["Created"];
            var modified = (DateTime)item["Modified"];
        }
    }
