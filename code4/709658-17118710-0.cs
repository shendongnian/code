    var client = new TcpClient();
    var result = client.BeginConnect("remotehost", this.Port, null, null);
    
    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
    
    if (!success)
    {
        throw new Exception("Failed to connect.");
    }
    // we have connected
    client.EndConnect(result);
