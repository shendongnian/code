    public File3D(string path)
    {
        // Initialize. Call InitFile3dPoints
    }
    ~File3D()
    {
        // Call Dispose(false)
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private IntPtr _data;
    
    private void Dispose(bool disposing)
    {
        // Unmanaged resource, ignore disposing parameter
        // and call DisposeFile3dPoints
    }
}
