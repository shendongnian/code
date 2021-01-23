    static void Main(string[] args)
    {
        IPEndPoint localpt = new IPEndPoint(IPAddress.Any, 6000);
    
        UdpClient udpServer = new UdpClient();
        udpServer.Client.SetSocketOption(
            SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        udpServer.Client.Bind(localpt);
    
        UdpClient udpServer2 = new UdpClient();
        udpServer2.Client.SetSocketOption(
            SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
    
        udpServer2.Client.Bind(localpt); // <<---------- No Exception here
    
        Console.WriteLine("Finished.");
        Console.ReadLine();
    }
