    class Program
        {
            static int port = 123;
            static AutoResetEvent waitHandle = new AutoResetEvent(false);
    
            static void Main(string[] args)
            {
                StartServer();
                waitHandle.WaitOne();
    
                int count = 0;
                while (true)
                {
                    Console.WriteLine("Client #" + count++);
                    StartClient();
                    Thread.Sleep(1000);
                }
            }
    
            static void StartClient()
            {
                using (TcpClient client = new TcpClient("1.1.1.1", port))
                {
                    using (NetworkStream networkStream = client.GetStream())
                    {
                        using (StreamWriter writer = new StreamWriter(networkStream))
                        {
                            writer.WriteLine("hello, tcp world");
                        }
                    }
                }
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
                            TcpClient client = listener.AcceptTcpClient();
    
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
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }, TaskCreationOptions.LongRunning);
            }
        }
