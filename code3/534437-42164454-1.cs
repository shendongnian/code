    public static void DisposeTimer()
    {
       MyTimer.Dispose(new InvalidWaitHandle());
       MyTimer = null;
    }
