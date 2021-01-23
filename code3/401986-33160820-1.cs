    public async Task SubmitDataToServer()
    {
      try
      {
        // Submit Data
      }
      catch
      {
        await LogExceptionAsync();
      }
      finally
      {
        await CloseConnectionAsync();
      }
    }
