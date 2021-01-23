    public static async Task RunAtIntervalAsync(TimeSpan pollInterval, Action action, CancellationToken token)
    {
        while(true)
        {
            await Task.Delay(pollInterval, token);
            action();
        }
    }
