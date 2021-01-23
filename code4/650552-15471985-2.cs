    public static class PeriodicRunner
    {
    public static Task DoPeriodicWorkAsync(Action workToPerform,
                                    TimeSpan dueTime, 
                                    TimeSpan interval, 
                                    CancellationToken token)
    {
      // Initial wait time before we begin the periodic loop.
      if(dueTime > TimeSpan.Zero)
        await Task.Delay(dueTime, token);
    
      // Repeat this loop until cancelled.
      while(!token.IsCancellationRequested)
      {
        workToPerform();
    
        // Wait to repeat again.
        if(interval > TimeSpan.Zero)
          await Task.Delay(interval, token);       
      }
    }
    }
