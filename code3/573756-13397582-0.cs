    private readonly Timer Timer;
    private readonly ManualResetEvent TimerDisposed;
    public Constructor()
    {
        Timer = ....;
        TimerDisposed = new ManualResetEvent(false);
    }
    public void Dispose()
    {
        Timer.Dispose(TimerDisposed);
        TimerDisposed.WaitOne();
        TimerDisposed.Dispose();
    }
