    public async Task DoSendMessageAsync(Message msg)
    {
      // Some async operations done here
    }
    public async Task SendMessageAsync(Message msg)
    {
      var task = DoSendMessageAsync(msg);
      MyCustomException exception = null;
      try
      {
        await task;
        return;
      }
      catch (MyCustomException ex)
      {
        exception = ex;
      }
      await Task.WhenAll(task, InsertFailureForMessageInDbAsync(msg, exception.ErrorCode));
    }
