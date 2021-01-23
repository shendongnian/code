    private object UpdateLock = new object();
    void DoUpdate()
    {
        if (!Monitor.TryEnter(UpdateLock))
        {
            // update already in progress
            return;
        }
        try
        {
            long currentTime = FrameTimer.ElapsedMilliseconds;
            if ((currentTime - LastUpdateTime) < MinUpdateMs)
            {
                // updated within the last 10 ms
                return;
            }
            LastUpdateTime = currentTime;
            if (CurrentFrame != null)
            {
                g.DrawImageUnscaled(CurrentFrame, 0,0);
            }
        }
        finally
        {
            Monitor.Exit(UpdateLock);
        }
    }
            
