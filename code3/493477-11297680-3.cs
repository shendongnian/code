    private void Dispose(bool disposing) 
    { 
        if (!_disposed) 
        { 
            try
            {
                _disposed = true; 
                _unitofWork.CallFuncList(); 
            }
            finally
            {
                Monitor.Exit(_unitofWork); //releasing the lock 
                GC.SuppressFinalize(this); 
            }
        } 
    } 
