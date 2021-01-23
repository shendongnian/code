        public static void ConnectTest(int count)
        {
            var ep = new IPEndPoint(IPAddress.Loopback, port);
            List<TcpClient> clients = new List<TcpClient>();
            for (var i = 0; i < count; i++)
            {
                TcpClient cl = new TcpClient();
                clients.Add(cl);
                cl.Connect(ep);
            }
        }
