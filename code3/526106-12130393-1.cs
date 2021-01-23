    class ClassHavingManagedAndUnManagedCode
        {
            private volatile bool _disposed = false;
    
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        //Do managed disposing here.
                    }
    
                    //Do unmanaged disposing here.
                }
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
    
                _disposed = true;
            }
    
            ~ClassHavingManagedAndUnManagedCode()
            {
                Dispose(false);
            }
        }
    
        class ClassHavingOnlyManagedCode
        {
            private volatile bool _disposed = false;
    
            public void Dispose()
            {
                if (_disposed)
                {
                    //Dispose managed objects.
                }
    
                _disposed = true;
            }
        }
