    public static R WithTimeout<R>(Func<R> proc, int duration)
    {
      var wh = proc.BeginInvoke(null, null);
      if (wh.AsyncWaitHandle.WaitOne(d))
      {
        return proc.EndInvoke(wh);
      }
      throw new TimeOutException();
    }
