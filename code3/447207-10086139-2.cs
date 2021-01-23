    public class FooEnvironment
    {
        private static int _initCount;
        private static object _environmentLock = new object();
        private bool _disposed;
        public FooEnvironment()
        {
            if (_initCount == 0)
            {
                lock (_environmentLock)
                {
                    if (_initCount == 0)
                    {
                        Init(); // global startup
                    }
                }
            }
            
            Interlocked.Increment(ref _initCount);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                // Dispose managed resources here
            }
            Interlocked.Decrement(ref _initCount);
            if (_initCount <= 0)
            {
                lock (_environmentLock)
                {
                    if (_initCount <= 0)
                    {
                        Term(); // global termination
                    }
                }
            }
            _disposed = true;
        }
        ~FooEnvironment()
        {
            Dispose(false);
        }
    }
