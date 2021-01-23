    public void Commit()
    {
        _unitofWork.CallFuncList(); 
    }
    
    private void Dispose(bool disposing) 
    { 
        if (!_disposed) 
        { 
            try
            {
                _disposed = true; 
            }
            finally
            {
                Monitor.Exit(_unitofWork); //releasing the lock 
                GC.SuppressFinalize(this); 
            }
        } 
    }
