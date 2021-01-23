    public async Task SendMessageAsync(Message msg)
    {
      try
      {           
        // Some async operations done here
      }
      catch (MyCustomException ex)
      {       
        var _ = InsertFailureForMessageInDbAsync(msg, ex.ErrorCode);
        throw;
      }
    }
