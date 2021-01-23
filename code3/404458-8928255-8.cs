    private volatile bool _disposed;
    public void Dispose()
    {
        if (!_disposed)
        {
    	    _disposed = true
            // disposal code here
        }
    }
