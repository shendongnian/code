    ~LoggingClass()
    {
        this.Dispose(false);
    }
    protected bool Disposed { get; private set; }
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!this.Disposed)
        {
            if (disposing)
            {
                // Perform managed cleanup here.
            }
            // Perform unmanaged cleanup here.
            this.Disposed = true;
        }
    }
