    class Program
    {
        static int port = 123;
        static string ip = "1.1.1.1";
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            StartServer();
            waitHandle.WaitOne();
            for (int x=0; x<1000; x++)
            {
                StartClient(x);
            }
            Console.WriteLine("Done starting clients");
            Console.ReadLine();
        }
        static void StartClient(int count)
        {
            Task.Factory.StartNew((paramCount) =>
            {
                int myCount = (int)paramCount;
                using (TcpClient client = new TcpClient(ip, port))
                {
                    using (NetworkStream networkStream = client.GetStream())
                    {
                        using (StreamWriter writer = new StreamWriter(networkStream))
                        {
                            writer.WriteLine("hello, tcp world #" + myCount);
                        }
                    }
                }
            }, count);
        }
        
        static void StartServer()
        {
            Task.Factory.StartNew(() => 
            {
                try
                {
                    TcpListener listener = new TcpListener(port);
                    listener.Start();
                    Console.WriteLine("Listening...");
                    waitHandle.Set();
                    while (true)
                    {
                        TcpClient theClient = listener.AcceptTcpClient();
                        Task.Factory.StartNew((paramClient) => {
                            TcpClient client = (TcpClient)paramClient;
                            byte[] buffer = new byte[32768];
                            MemoryStream memory = new MemoryStream();
                            using (NetworkStream networkStream = client.GetStream())
                            {
                                do
                                {
                                    int read = networkStream.Read(buffer, 0, buffer.Length);
                                    memory.Write(buffer, 0, read);
                                }
                                while (networkStream.DataAvailable);
                            }
                            string text = Encoding.UTF8.GetString(memory.ToArray());
                            Console.WriteLine("from client: " + text);
                        }, theClient);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
