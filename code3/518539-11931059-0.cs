        static string ReadData(NetworkStream network)
        {
            string Output = string.Empty;
            byte[] bReads = new byte[1024];
            int ReadAmount = 0;
            while (network.DataAvailable)
            {
                ReadAmount =
                    network.Read(bReads, 0, bReads.Length);
                Output += string.Format("{0}", Encoding.UTF8.GetString(
                    bReads, 0, ReadAmount));
            }
            return Output;
        }
        static void WriteData(NetworkStream stream, string cmd)
        {
            stream.Write(Encoding.UTF8.GetBytes(cmd), 0,
                    Encoding.UTF8.GetBytes(cmd).Length);
        }
        static void Main(string[] args)
        {
            List<TcpClient> clients = new List<TcpClient>();
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 1337));
            //listener.ExclusiveAddressUse = true; // One client only?
            listener.Start();
            Console.WriteLine("Server booted");
            Func<TcpClient, bool> SendMessage = (TcpClient client) => { 
                    WriteData(client.GetStream(), "Responeded to client");
                return true;
            };
            while (true)
            {
                if (listener.Pending()) {
                    clients.Add(listener.AcceptTcpClient());
                }
                foreach (TcpClient client in clients) {
                    if (ReadData(client.GetStream()) != string.Empty) {
                        Console.WriteLine("Request from client");
                        SendMessage(client);
                    }
                }
            }
        }
