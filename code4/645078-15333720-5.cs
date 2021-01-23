    class Program
    {
        static int port = 26140;
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            StartServer();
            waitHandle.WaitOne();
            Console.ReadLine();
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
                        Task.Factory.StartNew(paramClient =>
                        {
                            try
                            {
                                TcpClient client = (TcpClient) paramClient;
                                byte[] buffer = new byte[32768];
                                MemoryStream memory = new MemoryStream();
                                using (NetworkStream networkStream = client.GetStream())
                                {
                                    networkStream.ReadTimeout = 2000;
                                    do
                                    {
                                        int read = networkStream.Read(buffer, 0, buffer.Length);
                                        memory.Write(buffer, 0, read);
                                    } while (networkStream.DataAvailable);
                                    string text = Encoding.UTF8.GetString(memory.ToArray());
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("ERROR: " + e.Message);
                            }
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
