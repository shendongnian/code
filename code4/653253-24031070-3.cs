    public class TriggerLock
        : IDisposable
    {
        private static int _nUsing = 0;
        private bool _bDisposed;
    
        public TriggerLock()
        {
            _bDisposed = false;
            Interlocked.Increment(ref _nUsing);
        }
        ~TriggerLock()
        {
            Dispose(false);
        }
    
        public static bool IsOpened 
        {
            get { return _nUsing == 0; }
        }
    
        public void Dispose()
        {
            Dispose(true);
        }
        private void Dispose(bool bDisposing)
        {
            if (bDisposing && !_bDisposed)
            {
                Interlocked.Decrement(ref _nUsing);
                _bDisposed = true;
            }
        }
    }
