    public static async Task RunAtIntervalAsync(TimeSpan pollInterval, Task actionTask, CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(pollInterval, token);
            }
            catch(OperationCanceledException e)
            {
                // Swallow cancellation
                break;
            }
            await actionTask();
        }
    }
