    var broadcastMessage = Encoding.UTF8.GetBytes("Hello multicast!");
    var multicastAddress = IPAddress.Parse("239.255.255.250");
    var signal = new ManualResetEvent(false);
    var multicastPort = 1900;
    
    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
    {
        var multicastEp = new IPEndPoint(multicastAddress, multicastPort);
        EndPoint localEp = new IPEndPoint(IPAddress.Any, multicastPort);
    
        // Might want to set this:
        //socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1); 
        socket.Bind(localEp);
        socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(multicastAddress, IPAddress.Any));
        // May want to set this:
        //socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 0); // only LAN
        var thd = new Thread(() =>
            {
                var response = new byte[8000];
                socket.ReceiveFrom(response, ref localEp);
                var str = Encoding.UTF8.GetString(response).TrimEnd('\0');
                Console.WriteLine("[RECV] {0}", str);
                signal.Set();
                Console.WriteLine("Receiver terminating...");
            });
        signal.Reset();
        thd.Start();
    
        socket.SendTo(broadcastMessage, 0, broadcastMessage.Length, SocketFlags.None, multicastEp);
        Console.WriteLine("[SEND] {0}", Encoding.UTF8.GetString(broadcastMessage));
        signal.WaitOne();
        Console.WriteLine("Multicaster terminating...");
        socket.Close();
        Console.WriteLine("Press any key.");
        Console.ReadKey();
    }
