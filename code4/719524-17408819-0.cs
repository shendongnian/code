    public static Task<string> WhenFileCreated(string path)
    {
        var tcs = new TaskCompletionSource<string>();
        FileSystemWatcher watcher = new FileSystemWatcher(path);
        watcher.Created += (s, e) => tcs.SetResult(e.FullPath);
        watcher.EnableRaisingEvents=true;
        return tcs.Task;
    }
