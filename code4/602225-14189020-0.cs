    private async Task<string> ReadLineAsync()
    {
      ... // *Every* await in this method and every method it calls
          // must make use of ConfigureAwait(false).
    }
    public string ReadLine()
    {
      try
      {
        return ReadLineAsync().Result;
      }
      catch (AggregateException ex)
      {
        ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
        throw;
      }
    }
