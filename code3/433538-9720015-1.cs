    bool ProcessIsRunning(Process p)
    {
      bool isRunning;
      try {
        isRunning = !p.HasExited && p.Threads.Count > 0;
      }
      catch(SystemException sEx)
      {
        isRunning = false;
      }
      catch(PlatformNotSupportedException pnsEx)
      {
        throw;
      }
      return isRunning;
    }
