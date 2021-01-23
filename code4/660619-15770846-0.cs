    public bool ProcessMessage(string message)
    {
      var returnValue = GetReturnValue();
      Task.Run(async () => {
        //do some things with the message
        await UpdateDatabaseAsync();
        await SendRepliesOverNetworkAsync();
      });
      return returnValue;
    }
