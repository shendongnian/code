    private static IDictionary<string, FileSystemWatcher> _openWatchers
        = new Dictionary<string, FileSystemWatcher>();
    private static void Watch(string watch_folder)
    {
        if (!bCreateWatcher)
        {
            if (_openWatchers.ContainsKey(watch_folder))
            {
                _openWatchers[watch_folder].Dispose();
                _openWatchers.Remove(watch_folder);
            }
            return;
        }
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.InternalBufferSize = 8192; //defaults to 4KB, need 8KB buffer
        watcher.Path = watch_folder;
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        watcher.Filter = "*.*"; 
        watcher.Created += new FileSystemEventHandler(OnCreated);
        // Begin watching.
        try
        {
             watcher.EnableRaisingEvents = true;
             _openWatchers[watch_folder] = watcher;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ForegroundWindow.Instance, "FSW not set correctly" + ex, "FSW Error");
        }
     }
