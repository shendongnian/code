    private static async Task CheckAsync(CancellationToken token)
    {
      // Check your web service.
      await CheckWebServiceAsync(token);
      // Wait 5 minutes.
      await Task.Delay(TimeSpan.FromMinutes(5), token);
    }
    ...
    var done = new CancellationTokenSource(TimeSpan.FromHours(1));
    Task checkingTask = CheckAsync(done.Token);
    // When checkingTask completes:
    //   IsCanceled -> One hour passed with no errors.
    //   IsFaulted -> The web service failed.
