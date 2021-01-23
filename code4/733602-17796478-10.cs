    public static async Task RunAtIntervalAsync<T>(TimeSpan pollInterval, Func<Task<T>> fetchOperation, Action<T> operationOnResult, CancellationToken token)
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
            // Get a value
            T value = await fetchOperation();
            // Use result (ie: update UI)
            operationOnResult(value);
        }
    }
