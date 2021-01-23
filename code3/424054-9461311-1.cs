    public static R WithTimeout<R>(Func<R> proc, int duration)
    {
      var wh = proc.BeginInvoke(null, null);
      if (wh.AsyncWaitHandle.WaitOne(duration))
      {
        return proc.EndInvoke(wh);
      }
      throw new TimeOutException();
    }
