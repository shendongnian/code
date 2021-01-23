    static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(3);
    // operation contract
    public async Task Inc(int id)
    {
        await Semaphore.WaitAsync();
        try
        {
            Thread.Sleep(100);
            var result = id + 1;
            // do further processing using initiator service instance members
            // something like Callback.IncResult(result);
        }
        finally
        {
            Semaphore.Release();
        }
    }
