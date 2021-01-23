    Timespan timePerFrame = Timespan.FromMilliseconds(16);
    while (_isRunning)
    {
        Stopwatch timer = Stopwatch.StartNew()
        // Action.
        
        while (timer.ElapsedMilliseconds < timePerFrame) { /* Nothing? */ }
    }
