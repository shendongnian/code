    private Stopwatch FrameTimer = Stopwatch.StartNew();
    private long LastUpdateTime = 0;
    private const long MinUpdateMs = 10; // minimum time between updates
    
    void DoUpdate()
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
