    public class MyClass : IDisposable
    {
        private bool disposed = false;
        private ServiceHost host = null;
        public void StartListening(...)
        {
            // ....
        }
        public void StopListening()
        {
            // ...
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        { 
            if(!this.disposed)
            {
                if(disposing)
                {
                    this.StopListening();
                }
                disposed = true;
            }
        }
        ~MyClass()
        {
            Dispose(false);
        }
    }
