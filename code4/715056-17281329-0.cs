    class MSGServer
    {
        TcpListener server = null;
        Int32 port = 13000;
        IPAddress localAddr;
        private readonly BlockingCollection<ClientConn> ClientList = new BlockingCollection<ClientConn>();
        Byte[] data;
        public void CreateServer()
        {
            localAddr = IPAddress.Parse("172.26.114.71");
            server = new TcpListener(localAddr, port);
            server.Start();
            NewConnection();
        }
        public void NewConnection()
        {
            Debugger.Break();
            
            while (true)
            {
                ClientConn Client = new ClientConn();
                Client.TClient = server.AcceptTcpClient();
                NetworkStream stream = Client.TClient.GetStream();
                data = new Byte[256];
                String MSG = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                Client.ClientUserName = Encoding.ASCII.GetString(data, 0, bytes);
                stream.Write(data, 0, bytes);
                ClientList.Add(Client);
            }
        }
        public Boolean SendNotification(string UserName, string FFolder, string FName)
        {
            Debugger.Break();
            NetworkStream Stream;
            bool MsgSent = false;
            
            foreach (ClientConn Client in ClientList.GetConsumingEnumerable().Where(c => c.ClientUserName == UserName))
            {
                Byte[] MsgByte = Encoding.ASCII.GetBytes(FFolder + "|" + FName);
                Stream = Client.TClient.GetStream();
                Stream.Write(MsgByte, 0, MsgByte.Length);
                MsgSent = true;
            }
            return MsgSent;
        }
        public void CLoseAllConnections()
        {
            foreach (ClientConn ConnToClose in ClientList)
            {
                ConnToClose.TClient.Close();
            }
        }
    }
