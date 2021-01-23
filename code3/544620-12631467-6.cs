    void Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        TcpListener listener = new TcpListener(IPAddress.Any, 6666);
        try
        {
            listener.Start();
            //just fire and forget. We break from the "forgotten" async loops
            //in AcceptClientsAsync using a CancellationToken from `cts`
            AcceptClientsAsync(listener, cts.Token);
            Thread.Sleep(60000); //block here to hold open the server
        }
        finally
        {
            cts.Cancel();
            listener.Stop();
        }
    }
    async Task AcceptClientsAsync(TcpListener listener, CancellationToken ct)
    {
        var clientCounter = 0;
        while (!ct.IsCancellationRequested)
        {
            TcpClient client = await listener.AcceptTcpClientAsync()
                                                .ConfigureAwait(false);
            clientCounter++;
            //once again, just fire and forget, and use the CancellationToken
            //to signal to the "forgotten" async invocation.
            EchoAsync(client, clientCounter, ct);
        }
    }
    async Task EchoAsync(TcpClient client,
                         int clientIndex,
                         CancellationToken ct)
    {
        Console.WriteLine("New client ({0}) connected", clientIndex);
        using (client)
        {
            var buf = new byte[4096];
            var stream = client.GetStream();
            while (!ct.IsCancellationRequested)
            {
                //under some circumstances, it's not possible to detect
                //a client disconnecting if there's no data being sent
                //so it's a good idea to give them a timeout to ensure that 
                //we clean them up.
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(15));
                var amountReadTask = stream.ReadAsync(buf, 0, buf.Length, ct);
                var completedTask = await Task.WhenAny(timeoutTask, amountReadTask)
                                              .ConfigureAwait(false);
                if (completedTask == timeoutTask)
                {
                    var msg = Encoding.ASCII.GetBytes("Client timed out");
                    await stream.WriteAsync(msg, 0, msg.Length);
                    break;
                }
                //now we know that the amountTask is complete so
                //we can ask for its Result without blocking
                var amountRead = amountReadTask.Result;
                if (amountRead == 0) break; //end of stream.
                await stream.WriteAsync(buf, 0, amountRead, ct)
                            .ConfigureAwait(false);
            }
        }
        Console.WriteLine("Client ({0}) disconnected", clientIndex);
    }
