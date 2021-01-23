    public class MyUnitOfWork : IDisposable
    {
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // this block is for managed resources
                }
                context.Dispose();
                this.disposed = true;
            }
        }
        public void Dispose() // IDisposable implementation
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~MyUnitOfWork()
        {
            Dispose(false);
        }
        // ...
    }
