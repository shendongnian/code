    private async Task DoPeriodicWorkAsync(TimeSpan dueTime, 
                                           TimeSpan interval, 
                                           CancellationToken token)
    {
      // Initial wait time before we begin the periodic loop.
      if(dueTime > TimeSpan.Zero)
        await Task.Delay(dueTime, token);
      // Repeat this loop until cancelled.
      while(!token.IsCancellationRequested)
      {
        // TODO: Do some kind of work here. 
        // Wait to repeat again.
        if(interval > TimeSpan.Zero)
          await Task.Delay(interval, token);       
      }
    }
