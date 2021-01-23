    public class MyObject : IDisposable
    {
        // Some unmanaged resource:
        UnmanagedResource unmanaged;
        
        // Finalizer:
        ~MyObject
        {
            DisposeUnmanaged();
        }
        
        public void Dispose()
        {
            DisposeManaged();
            DisposeUnmanaged();
            GC.SuppressFinalize(this);
        }
        
        protected virtual DisposeManaged()
        {
            // Dispose _managed_ resources here.
        }
        
        protected virtual DisposeUnmanaged()
        {
            // Dispose _unmanaged_ resources here.
            this.unmanaged.FreeMe();
            this.unmanaged = null;
        }
    }
