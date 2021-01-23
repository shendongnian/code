    void CreateServer()
    {
        TcpListener tcp = new TcpListener(25565);
        tcp.Start();
        Thread t = new Thread(()=>
        {
            while (true)
            {
                var tcpClient = tcp.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem((_) =>
                {
                    //Your server codes handling client's request.
                    //Don't access UI control directly here
                    //Use "Invoke" instead. 
                    tcpClient.Close();
                },null);
            }
        });
        t.IsBackground = true;
        t.Start();
    }
