    [ConfigurationProperty("WatchedFolders")]
    public WatchedFolderElementCollection WatchedFolders
    {
       get { return this["WatchedFolders"] as WatchedFolderElementCollection; }
    }
