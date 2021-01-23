    [Flags]
    public enum WatchFileType
    {
        Created = 1,
        Deleted = 2,
        Changed = 4,
        Renamed = 8,
        Exists = 16,
        ExistsNotEmpty = 32,
        NotExists = 64,
    }
    public static Task<WatchFileType> WatchFile(string filePath,
        WatchFileType watchTypes,
        int timeout = Timeout.Infinite,
        CancellationToken cancellationToken = default)
    {
        var tcs = new TaskCompletionSource<WatchFileType>();
        var fileName = Path.GetFileName(filePath);
        var folderPath = Path.GetDirectoryName(filePath);
        var fsw = new FileSystemWatcher(folderPath);
        fsw.Filter = fileName;
        if (watchTypes.HasFlag(WatchFileType.Created)) fsw.Created += Handler;
        if (watchTypes.HasFlag(WatchFileType.Deleted)) fsw.Deleted += Handler;
        if (watchTypes.HasFlag(WatchFileType.Changed)) fsw.Changed += Handler;
        if (watchTypes.HasFlag(WatchFileType.Renamed)) fsw.Renamed += Handler;
        void Handler(object sender, FileSystemEventArgs e)
        {
            WatchFileType result;
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created: result = WatchFileType.Created; break;
                case WatcherChangeTypes.Deleted: result = WatchFileType.Deleted; break;
                case WatcherChangeTypes.Changed: result = WatchFileType.Changed; break;
                case WatcherChangeTypes.Renamed: result = WatchFileType.Renamed; break;
                default: throw new NotImplementedException(e.ChangeType.ToString());
            }
            fsw.Dispose();
            tcs.TrySetResult(result);
        }
        fsw.Error += (object sender, ErrorEventArgs e) =>
        {
            fsw.Dispose();
            tcs.TrySetException(e.GetException());
        };
        CancellationTokenRegistration cancellationTokenReg = default;
        fsw.Disposed += (object sender, EventArgs e) =>
        {
            cancellationTokenReg.Dispose();
        };
        fsw.EnableRaisingEvents = true;
        var fileInfo = new FileInfo(filePath);
        if (watchTypes.HasFlag(WatchFileType.Exists) && fileInfo.Exists)
        {
            fsw.Dispose();
            tcs.TrySetResult(WatchFileType.Exists);
        }
        if (watchTypes.HasFlag(WatchFileType.ExistsNotEmpty)
            && fileInfo.Exists && fileInfo.Length > 0)
        {
            fsw.Dispose();
            tcs.TrySetResult(WatchFileType.ExistsNotEmpty);
        }
        if (watchTypes.HasFlag(WatchFileType.NotExists) && !fileInfo.Exists)
        {
            fsw.Dispose();
            tcs.TrySetResult(WatchFileType.NotExists);
        }
        if (cancellationToken.CanBeCanceled)
        {
            cancellationTokenReg = cancellationToken.Register(() =>
            {
                fsw.Dispose();
                tcs.TrySetCanceled(cancellationToken);
            });
        }
        if (tcs.Task.IsCompleted || timeout == Timeout.Infinite)
        {
            return tcs.Task;
        }
        // Handle timeout
        var cts = new CancellationTokenSource();
        var delayTask = Task.Delay(timeout, cts.Token);
        return Task.WhenAny(tcs.Task, delayTask).ContinueWith(_ =>
        {
            cts.Cancel();
            if (tcs.Task.IsCompleted) return tcs.Task;
            fsw.Dispose();
            return Task.FromCanceled<WatchFileType>(cts.Token);
        }, TaskContinuationOptions.ExecuteSynchronously).Unwrap();
    }
