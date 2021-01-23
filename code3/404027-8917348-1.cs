    private void TimerFired(object sender, System.Timers.ElapsedEventArgs e) {
        // only execute the code within this method if we are able to
        // get a lock. This will ensure that any Timer firings will be
        // ignored that occur while we're already doing work (OnTimer) 
        if (Monitor.TryEnter(lockObj)) {
            try {
                // do work here
            } finally {
                Monitor.Exit(lockObj);
            }
        }
    }
