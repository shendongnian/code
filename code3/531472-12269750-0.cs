    static void Main(string[] args)
    {
        SocketTest();
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
    public static void SocketTest()
    {
        int port = 22345;
        var tcpListener = new TcpListener(IPAddress.Any, port);
        tcpListener.Start();
        // Listening thread
        new Thread(() =>
        {
            var socket = tcpListener.AcceptSocket();
            var stream = new NetworkStream(socket);
            var reader = new BinaryReader(stream);
            try
            {
                Console.WriteLine("Starting blocking read");
                var bytes = reader.ReadBytes(1);
                Console.WriteLine("Done blocking read, read {0} bytes", bytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading " + ex);
            }
        }).Start();
        // connecting thread
        new Thread(() =>
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", port);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Disposing of socket");
            socket.Dispose();
        }).Start();
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }
