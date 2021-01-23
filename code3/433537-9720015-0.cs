    bool ProcessIsRunning(Process p)
    {
      bool isRunning = !p.HasExited && p.Threads.Count > 0;
      try {
        var id = p.Id;
      }
      catch(InvalidOperationException ioEx)
      {
        isRunning = false;
      }
      catch(PlatformNotSupportedException pnsEx)
      {
        throw;
      }
      return isRunning;
    }
