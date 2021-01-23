    FileSystemWatcher _watcher;
    int _watcherEventFiredCounter;
    _watcher = new FileSystemWatcher {
        Path = @"C:\temp",
        NotifyFilter = NotifyFilters.LastWrite,
        Filter = "*.zip",
        EnableRaisingEvents = true
    };
    _watcher.Changed += OnChanged;
        
    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        _watcherEventFiredCounter++;
        // The event is fired two times: on start copying and on finish copying
        if (_watcherEventFiredCounter == 2) {
            Console.WriteLine("Copying is finished now!");
            _watcherEventCounter = 0;
        }
    }
