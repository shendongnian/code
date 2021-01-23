    public void timerControl()
    {
      if (!active) formTimer = new System.Threading.Timer(new TimerCallback(TimerProc));
      try
      {
        formTimer.Change(REFRESH_STATUS_TIME_INTERVAL, 0);
      }
      catch {}
      active = true;
    }
