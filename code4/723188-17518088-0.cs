    private readonly AsyncLock asyncLock = new AsyncLock();
    public async Task<TResult> EnqueueOperation<TResult>(
        Func<Task<TResult>> continuationFunction)
    {
        using (await asyncLock.LockAsync())
        {
            return await continuationFunction();
        }
    }
