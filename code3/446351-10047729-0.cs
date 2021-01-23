    class Worker
    {
        private Thread _thread;
        // Un-paused by default.
        private ManualResetEvent _notToBePaused = new ManualResetEvent(true);
        public Worker()
        {
            _thread = new Thread(Run)
                {
                    IsBackground = true
                };
        }
        /// <summary>
        /// Thread function.
        /// </summary>
        private void Run()
        {
            while (true)
            {
                // Would block if paused!
                _notToBePaused.WaitOne();
                
                // Process some stuff here.
            }
        }
        public void Start()
        {
            _thread.Start();
        }
        public void Pause()
        {
            _notToBePaused.Reset();
        }
        public void UnPause()
        {
            _notToBePaused.Set();
        }
    }
