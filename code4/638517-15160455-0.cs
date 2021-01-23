    namespace abc
    {
        public class Action: IDisposable
        {
            private bool _disposed;
            Entities context= new Entities();
            // all the methods
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                        // Dispose other managed resources.
                    }
                    //release unmanaged resources.
                }
                _disposed = true;
            }
        }
    }
