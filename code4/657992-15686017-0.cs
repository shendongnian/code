    public async Task<MessageResponse> GetResult(Message message)
    {
      var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
      try
      {
        return await Task.Run(() => worker.ProcessMessage(message, cts.Token));
      }
      catch (OperationCanceledException)
      {
        return "Your request is taking longer than usual";
      }
    }
