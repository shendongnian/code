    namespace SocketServer    
    {
        class Program
        {
            static Socket klient; 
            static void Main(string[] args)
            {
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8888); 
                server.Bind(endPoint);
                server.Listen(20);
                while(true)
                {
                    Console.WriteLine("Waiting...");
                    klient = server.Accept();
    
                    Console.WriteLine("Client connected");
                    Task t = new Task(ServisClient);
                    t.Start();
                }
            }
    
            static void ServisClient()
            {
                try
                {
                    while (true)
                    {
                        byte[] buffer = new byte[64];
                        Console.WriteLine("Waiting for answer...");
                        klient.Receive(buffer, 0, buffer.Length, 0);
                        string message = Encoding.UTF8.GetString(buffer);
                        Console.WriteLine("Answer: " + message);
    
                        string answer = "Actualy date is " + DateTime.Now;
                        buffer = Encoding.UTF8.GetBytes(answer);
                        Console.WriteLine("Sending {0}", answer);
                        klient.Send(buffer);
                    }
                }
                catch
                {
                    Console.WriteLine("Disconnected");
                }
            }
        }
    }
