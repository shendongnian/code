    if (Monitor.TryEnter(_lock))
    {
        try
        {
            if (currentTime.Subtract(_lastTriggered).Duration().TotalMinutes >
                _autoReduceInterval)
            {
                _lastTriggered = currentTime;
                shouldRun = true;
            } 
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }
