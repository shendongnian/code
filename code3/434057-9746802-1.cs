    private async Task StartReceive()
    {
      try
      {
        var buffer = new byte[1024];
        while (true)
        {
          var bytesReceived = await socket.ReceiveAsyncTask(buffer, 0, 1024)
              .ConfigureAwait(false);
          ProcessData(buffer, bytesReceived);
        }
      }
      catch (Exception ex)
      {
        // Handle errors here
      }
    }
