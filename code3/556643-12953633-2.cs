    var worker = new BackgroundWorker();
    worker.WorkerReportsProgress = true;
    worker.WorkerSupportsCancellation = true;
    worker.ProgressChanged += (s, args) =>
    {
        Console.WriteLine(args.UserState);
    }
    worker.DoWork += (s, args) =>
    {
        // startup the server on localhost
        var ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
        TcpListener server = new TcpListener(ipAddress, clientPort);
        server.Start();
        while (!worker.CancellationPending)
        {
            // as long as we're not pending a cancellation, let's keep accepting requests
            TcpClient client = server.AcceptTcpClient();
            
            StreamReader clientIn = new StreamReader(client.GetStream());
            StreamWriter clientOut = new StreamWriter(client.GetStream());
            clientOut.AutoFlush = true;
            
            while ((string msg = clientIn.ReadLine()) != null)
            {
                worker.ReportProgress(1, msg);  // this will fire the ProgressChanged event
                clientOut.WriteLine(msg);
            }
        }
    }
