    private async void RunAfterDelay(TimeSpan delay, CancellationToken token, Action action)
    {
        await Task.Delay(delay, token);
        if (!token.IsCancellationRequested)
        {
            action();
        }
    }
    private void RunWatcher()
    {
        var cts = new CancellationTokenSource();
        var watcher = new FileSystemWatcher();
        watcher.Path = "...";
        watcher.Created += (_, e) =>
        {
            if (e.FullPath == "file-you-are-interested-in")
            {
               // cancel the timer
               cts.Cancel();
               // do your stuff
               // ...
               // get rid of the watcher
               watcher.Dispose();
            }
        };
        watcher.EnableRaisingEvents = true;
        // start the timer
        RunAfterDelay(TimeSpan.FromMinutes(10), cts.Token, () =>
        {
            // get rid of the watcher
            watcher.Dispose();
            // do anything else you want to do, like send out failure notices.
        });
    }
