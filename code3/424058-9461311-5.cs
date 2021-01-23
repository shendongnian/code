    public static R WithTimeout<R>(Func<R> proc, int duration)
    {
      var reset = new AutoResetEvent(false);
      var r = default(R);
      Exception ex = null;
      var t = new Thread(() =>
      {
        try
        {
          r = proc();
        }
        catch (Exception e)
        {
          ex = e;
        }
        reset.Set();
      });
      t.Start();
      
      // not sure if this is really needed in general
      while (t.ThreadState != ThreadState.Running)
      {
        Thread.Sleep(0);
      }
      if (!reset.WaitOne(duration))
      {
        t.Abort();
        throw new TimeoutException();
      }
      if (ex != null)
      {
        throw ex;
      }
      return r;
    }
