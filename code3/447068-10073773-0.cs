    public void Execute(object sender, EventArgs e)
    {
        var currentTime = DateTime.Now;
        var shouldRun = false;
        lock (_lock)
        {
            TimeSpan span = currentTime - _lastTriggeed;
            if (span.TotalMinutes > _autoReduceInterval)
            {
                _lastTriggered = currentTime;
                shouldRun = true;
            }
        }
        if (shouldRun)
        {
            Task.Factory.StartNew(() =>
            {
                //Trigger reduce which is a long running task
            }, TaskCreationOptions.LongRunning);
        }
    }
