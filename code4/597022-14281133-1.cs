    private void TimerProc(object state)
    {
      System.Threading.Timer t = (System.Threading.Timer)state;
      t.Dispose();
      try
      {
        CloseScreen();
      }
      catch{}
    }
