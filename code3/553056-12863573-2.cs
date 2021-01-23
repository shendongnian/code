    protected virtual void Dispose(bool disposing)         
    {         
        if (disposing)         
        {         
            if (ns != null)         
            {         
                ns.Dispose();         
            }         
            if (tc != null)         
            {         
                tc.Dispose();         
            }         
        }         
    }         
         
    public void Dispose()         
    {         
        Dispose(true);         
        GC.SuppressFinalize(this);         
    }         
