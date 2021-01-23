    public sealed class Locker: IDisposable
    {
        readonly object _lockObject;
        readonly bool _wasLockAcquired;
        public Locker(object lockObject, TimeSpan timeout)
        {
            _lockObject = lockObject;
            Monitor.TryEnter(_lockObject, timeout, ref _wasLockAcquired);
            // Throw if lock wasn't acquired?
        }
        public bool WasLockAquired
        {
            get
            {
                return _wasLockAcquired;
            }
        }
        public void Dispose()
        {
            if (_wasLockAcquired)
                Monitor.Exit(_lockObject);
        }
    }
