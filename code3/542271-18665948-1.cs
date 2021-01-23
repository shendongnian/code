    private static readonly object _locker = new object();
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (!Monitor.TryEnter(_locker)) { return; }  // Don't let  multiple threads in here at the same time.
            try
            {
                // do stuff
            }
            finally
            {
                Monitor.Exit(_locker);
            }
        }
