    class YourApp : IDisposable 
    {
        private readonly Mutex _mutex;
        private bool _isFirstInstance;
        public YourApp()
        {
            _mutex = new Mutex(false, "myMutex");
        }
        ~YourApp()
        {
            this.Dispose(false);
            GC.SurpressFinalize(this);
        }
        public bool IsFirstInstance
        {
            if(_isFirstInstance)
                return true;
               
            _isFirstInstance = _mutex.WaitOne (TimeSpan.FromSeconds(1d), false);
            return _isFirstInstance;
        }
        private bool IsDisposed { get; set; }
        public void Dispose()
        {
            this.Dispose(true);
        }
        private void Dispose(bool disposing)
        {
            if(this.IsDisposed)
               return;
            if(disposing)
               _mutex.Dispose();
            this.IsDisposed = true;
        }
    }
