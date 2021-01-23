    private int _inUseCount;
    public void MyMethod()
    {
        if (Interlocked.Increment(ref _inUseCount) == 1)
        {
            // do dome stuff    
        }
        Interlocked.Decrement(ref _inUseCount);
    }
