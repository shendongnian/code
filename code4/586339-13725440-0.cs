    var fsw = new FileSystemWatcher(@"C:\pathtoyourfile");
    fsw.Changed += TheFileChanged;
        
    private void TheFileChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Changed)
        {
            var info = new FileInfo(e.FullPath);
            var theSize = info.Length;
        }
    }
