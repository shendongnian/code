    public FooEnvironment()
    {
        if(Interlocked.Increment(ref _initCount) == 1)
        {
            Init();  // global startup
        }
    }
    private void Dispose(bool disposing)
    {
        if(_disposed)
            return;
        if(disposing)
        {
            if(Interlocked.Decrement(ref _initCount) == 0)
            {
                Term(); // global termination
            }
        }
    }
