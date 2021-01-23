    public class DataProcessor : IDisposable
    {
        private bool disposed = false; 
        DispatchTimer timer;
    
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if(timer != null)
                       timer.Stop();
                }
    
                disposed = true;
            }
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
        ~DataProcessor()
        {
            Dispose(false);
        }
    }
