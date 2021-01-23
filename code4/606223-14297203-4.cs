    // The `onTick` method will be called periodically unless cancelled.
    private static async Task RunPeriodicAsync(Action onTick,
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
        // Call our onTick function.
        onTick?.Invoke();
        // Wait to repeat again.
        if(interval > TimeSpan.Zero)
          await Task.Delay(interval, token);       
      }
    }
