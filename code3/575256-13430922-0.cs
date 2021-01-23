    public Task MyDelay(int milliseconds)
    {
        // There's only a generic TaskCompletionSource, but we don't really
        // care about the result. Just use int as a reasonably cheap version.
        var tcs = new TaskCompletionSource<int>();
        Timer timer = new Timer(_ => tcs.SetResult(0), null, milliseconds,
                                Timeout.Infinite);
        // Capture the timer variable so that the timer can't be garbage collected
        // unless the task is (in which case it doesn't matter).
        tcs.Task.ContinueWith(task => timer = null);
        return tcs.Task;
    }
