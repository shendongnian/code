    IPEndPoint ServerEndPoint= new IPEndPoint(IPAddress.Any,9050);
    Socket WinSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    WinSocket.Bind(ServerEndPoint);
    
    Console.Write("Waiting for client");
    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0)
    EndPoint Remote = (EndPoint)(sender);
    int recv = WinSocket.ReceiveFrom(data, ref Remote);
    Console.WriteLine("Message received from {0}:", Remote.ToString());
    Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
