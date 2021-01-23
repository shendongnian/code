    void Dispose() { Dispose(true); }
    void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Free managed resources
        }
        // always free unmanaged resources
    }
    ~Finalizer() { Dispose (false); }
