    public static Task<bool> SendPacketBoolAsync(string type, string data)
    {
        var tcs = new TaskCompletionSource<bool>();
        try
        {
            NetworkComms.SendObject(type, serverIp, serverPort, data);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("ClientV",
               (header, connection, array) =>
               {
                  if (array == "false")
                  {
                     tcs.TrySetResult(false);
                  }
                  else
                  {
                     tcs.TrySetResult(true);
                  }
               });
        }
        catch (Exception ex)
        {
             tcs.TrySetException(ex);
        }
        
        return tcs.Task;
    }
