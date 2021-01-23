    static string ReadData(NetworkStream network)
    {
        string Output = string.Empty;
        byte[] bReads = new byte[1024];
        int ReadAmount = 0;
        while (network.DataAvailable)
        {
            ReadAmount = network.Read(bReads, 0, bReads.Length);
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
        TcpClient client = new TcpClient();
        client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1337));
        while (!client.Connected) { } // Wait for connection
        WriteData(client.GetStream(), "Send to server");
        while (true) {
            NetworkStream strm = client.GetStream();
            if (ReadData(strm) != string.Empty) {
                Console.WriteLine("Recieved data from server.");
            }
        }
    }
