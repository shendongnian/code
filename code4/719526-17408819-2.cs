    public static Task WhenFileCreated(string path)
    {
        if (File.Exists(path))
            return Task.FromResult(true);
        var tcs = new TaskCompletionSource<bool>();
        FileSystemWatcher watcher = new FileSystemWatcher(Path.GetDirectoryName(path));
        FileSystemEventHandler createdHandler = null;
        RenamedEventHandler renamedHandler = null;
        createdHandler = (s, e) =>
        {
            if (e.Name == Path.GetFileName(path))
            {
                tcs.TrySetResult(true);
                watcher.Created -= createdHandler;
                watcher.Dispose();
            }
        };
        renamedHandler = (s, e) =>
        {
            if (e.Name == Path.GetFileName(path))
            {
                tcs.TrySetResult(true);
                watcher.Renamed -= renamedHandler;
                watcher.Dispose();
            }
        };
        watcher.Created += createdHandler;
        watcher.Renamed += renamedHandler;
        watcher.EnableRaisingEvents = true;
        return tcs.Task;
    }
