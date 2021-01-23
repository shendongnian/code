    public async static Task Delay(int millisecondsTimeout)
    {
        var tcs = new TaskCompletionSource<bool>();
        new Timer(self =>
        {
            ((IDisposable)self).Dispose();
            tcs.TrySetResult(true);
        }).Change(millisecondsTimeout, -1);
        await tcs.Task;
    }
