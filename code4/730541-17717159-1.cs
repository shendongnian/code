    public static Task Delay(double milliseconds)
    {
        var tcs = new TaskCompletionSource<bool>();
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Elapsed += (o, e) => tcs.TrySetResult(true);
        timer.Interval = milliseconds;
        timer.AutoReset = false;
        timer.Start();
        return tcs.Task;
    }
