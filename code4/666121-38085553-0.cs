    string[] drives = Environment.GetLogicalDrives();
    
    foreach(string drive in drives)
    {
       FileSystemWatcher watcher = new FileSystemWatcher();
       watcher.Path = drive;
       watcher.IncludeSubdirectories = true;
       watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
       
       watcher.Filter = "*.txt";
             
       watcher.Changed += new FileSystemEventHandler(OnChanged);
       watcher.Created += new FileSystemEventHandler(OnChanged);
       watcher.Deleted += new FileSystemEventHandler(OnChanged);
       watcher.Renamed += new RenamedEventHandler(OnRenamed);
    
       watcher.EnableRaisingEvents = true;
}
