    // Create a new FileSystemWatcher and set its properties.
    FileSystemWatcher watcher = new FileSystemWatcher();
    watcher.Path = args[1];
    // Watch for changes in LastAccess and LastWrite times, and
    // the renaming of files or directories.
    watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
    // Only watch text files.
    watcher.Filter = "*.txt";
    // Add event handlers.
    watcher.Changed += new FileSystemEventHandler(OnChanged);
    watcher.Created += new FileSystemEventHandler(OnChanged);
    watcher.Deleted += new FileSystemEventHandler(OnChanged);
    watcher.Renamed += new RenamedEventHandler(OnRenamed);
    // Begin watching.
    watcher.EnableRaisingEvents = true;
