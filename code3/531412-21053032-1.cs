    private void WatcherOnCreated(object sender, FileSystemEventArgs e)
    {
        if (GetIdleFile(e.FullPath))
        {
            // Do something like...
            foreach (var line in File.ReadAllLines(e.FullPath))
            {
                // Do more...
            }
        }
    }
