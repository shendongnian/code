    private volatile int _disposeCount;
    
    public void Dispose()
    {
        if (Interlocked.Increment(ref _disposeCount) == 1)
        {
            // disposal code here
        }
    }
