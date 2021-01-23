    public static void Connect1(string host, int port)
    {
        IPAddress[] IPs = Dns.GetHostAddresses(host);
    
        Socket s = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);
    
        Console.WriteLine("Establishing Connection to {0}", 
            host);
        s.Connect(IPs[0], port); // Catch any exceptions here.
        Console.WriteLine("Connection established");
    }	
