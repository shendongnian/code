    static ManualResetEvent _inited = new ManualResetEvent(false);
    public FooEnvironment()
    {
        if(Interlocked.Increment(ref _initCount) == 1)
        {
            Init();  // global startup
            _inited.Set();
        }
        _inited.WaitOne();
    }
    private void Dispose(bool disposing)
    {
        if(_disposed)
            return;
        if(disposing)
        {
            if(Interlocked.Decrement(ref _initCount) == 0)
            {
                _inited.Reset();
                Term(); // global termination
            }
        }
    }
