        static void Main(string[] args)
        {
            IPEndPoint localpt = new IPEndPoint(IPAddress.Loopback, 6000);
            ThreadPool.QueueUserWorkItem(delegate
            {
                UdpClient udpServer = new UdpClient();
                udpServer.ExclusiveAddressUse = false;
                udpServer.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpServer.Client.Bind(localpt);
                IPEndPoint inEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Console.WriteLine("Listening on " + localpt + ".");
                byte[] buffer = udpServer.Receive(ref inEndPoint);
                Console.WriteLine("Receive from " + inEndPoint + " " + Encoding.ASCII.GetString(buffer) + ".");
            });
            Thread.Sleep(1000);
            UdpClient udpServer2 = new UdpClient();
            udpServer2.ExclusiveAddressUse = false;
            udpServer2.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpServer2.Client.Bind(localpt);
            udpServer2.Send(new byte[] { 0x41 }, 1, localpt);
            Console.Read();
        }
