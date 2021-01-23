    private bool m_disposed;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public void Dispose(bool disposing)
    {
        if (!m_disposed)
        {
            if (disposing)
                // Cleanup and close resources
            m_disposed = true;
        }
    }
