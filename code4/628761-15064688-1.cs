    bool _disposing = false  // class property
    public void Dispose()
    {
        if( !disposing ) 
            Marshal.ReleaseComObject(importInterface);
        importInterface = null; 
        GC.SuppressFinalize(this);
        disposing = true;
    }
 
