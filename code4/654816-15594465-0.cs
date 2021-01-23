    static void Main(string[] args)
    {
    	while (true)
    	{
    
    		Int32 port = 14000;
    		IPAddress local = IPAddress.Parse("127.0.0.1");
    
    		TcpListener serverSide = new TcpListener(local, port);
    		serverSide.Start();
    		Console.Write("Waiting for a connection with client... ");
    		TcpClient clientSide = serverSide.AcceptTcpClient();
    		Task.Factory.StartNew(HandleClient, clientSide);
    	}
    }
    
    static void HandleClient(object state)
    {
    	TcpClient clientSide = state as TcpClient;
    	if (clientSide == null)
    		return;
    
    	Console.WriteLine("Connected with Client");
    	clientSide.Close();
    }
