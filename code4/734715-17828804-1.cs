    String folderLocation = System.Configuration.ConfigurationManager.AppSettings["FOLDER_LOCATION"].ToString();
    
                _watcher = new System.IO.FileSystemWatcher();
                _watcher.Path = folderLocation;
                _watcher.IncludeSubdirectories = false;
                _watcher.NotifyFilter = NotifyFilters.Size;
                _watcher.Changed += new FileSystemEventHandler(OnFileChanged);
                _watcher.EnableRaisingEvents = true;
    private void OnFileChanged(object sender, FileSystemEventArgs e)
            {
                String file = e.FullPath;
    ...
