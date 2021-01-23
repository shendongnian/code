    public class Disposable : IDisposable
        {
            private bool isDisposed;
    
            ~Disposable()
            {
                Dispose(false);
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            private void Dispose(bool disposing)
            {
                if (!isDisposed && disposing)
                {
                    DisposeCore();
                }
    
                isDisposed = true;
            }
    
           
        }   
