        class ClassHavingOnlyManagedCode  : IDiposable
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
