    private bool _isDisposed;
    
    public void Dispose()
    {
        Dispose(true);
    }
    
    protected virtual void Dispose(bool disposing)
    {
       if (_isDisposed)
          return;
    
       if (disposing)
       {
           if (font != null)
               font.Dispose();
       }
    
       _isDisposed = true;
    
    }
