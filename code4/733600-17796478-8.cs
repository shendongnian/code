    public static async Task RunAtIntervalAsync(TimeSpan pollInterval, Action action, CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(pollInterval, token);
                action();
            }
            catch(OperationCanceledException e)
            {
                // Swallow cancellation - dangerous if action() throws this, though....
                break;
            }
        }
    }
