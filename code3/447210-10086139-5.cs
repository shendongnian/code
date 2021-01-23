    public class FooEnvironment
    {
        private static int _initCount;
        private static bool _initialized;
        private static object _environmentLock = new object();
        private bool _disposed;
        public FooEnvironment()
        {
            Interlocked.Increment(ref _initCount);
            if (_initCount > 0 && !_initialized)
            {
                lock (_environmentLock)
                {
                    if (_initCount > 0 && !_initialized)
                    {
                        Init(); // global startup
                        _initialized = true;
                    }
                }
            }
        }
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                // Dispose managed resources here
            }
            Interlocked.Decrement(ref _initCount);
            if (_initCount <= 0 && _initialized)
            {
                lock (_environmentLock)
                {
                    if (_initCount <= 0 && _initialized)
                    {
                        Term(); // global termination
                        _initialized = false;
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
