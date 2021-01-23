    void Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        TcpListener listener = new TcpListener(IPAddress.Any,6666);
        try
        {
            listener.Start();
            AcceptClientsAsync(listener, cts.Token);
            Thread.Sleep(60000); //block here to hold open the server
        }
        finally
        {
            cts.Cancel();
            listener.Stop();
        }
    
        cts.Cancel();
    }
    
    async Task AcceptClientsAsync(TcpListener listener, CancellationToken ct)
    {
        while(!ct.IsCancellationRequested)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
            EchoAsync(client, ct);
        }
    
    }
    async Task EchoAsync(TcpClient client, CancellationToken ct)
    {
        var buf = new byte[4096];
        var stream = client.GetStream();
        while(!ct.IsCancellationRequested)
        {
            var amountRead = await stream.ReadAsync(buf, 0, buf.Length, ct);
            if(amountRead == 0) break; //end of stream.
            await stream.WriteAsync(buf, 0, amountRead, ct);
        }
    }
