    void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
    {
        lock (filesChangeCount)
        {
            int count;
            filesChangeCount.TryGetValue(e.FullPath, out count);
            filesChangeCount[e.FullPath] = count++;
        }
    }
