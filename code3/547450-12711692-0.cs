        static void Main(string[] args)
        {
            bool keepTrying = true;
            while (keepTrying)
            {
                Console.Write("Enter server IP Address: ");
                IPAddress ip = null;
                if(!IPAddress.TryParse(Console.ReadLine(), out ip))
                {
                    Console.WriteLine("Invalid ip entered, defaulting to 192.168.178.11");
                    ip = IPAddress.Parse("192.168.178.11");
                }
                Console.Write("Enter server port: ");
                Int16 port = 0;
                if(!Int16.TryParse(Console.ReadLine(), out port))
                {
                    Console.WriteLine("Invalid port entered, defaulting to 1234");
                    port = 1234;
                }
                Console.WriteLine("Connecting.....");
                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect(new IPEndPoint(ip, port));
                    client.NoDelay = false;
                    Console.WriteLine("Connection succesfull!");
                    List<byte> data = new List<byte>() { 2, 29 };
                    Console.Write("Please enter a username: ");
                    byte[] userName = ASCIIEncoding.ASCII.GetBytes(Console.ReadLine());
                    data.AddRange(userName);
                    using (var stream = client.GetStream())
                    {
                        stream.Write(data.ToArray(), 0, data.Count);
                        Console.Write("Data sent!");
                    }
                    keepTrying = false;
                }
                catch
                {
                    Console.WriteLine("--== ERROR CONNECTING ==--");
                    Console.WriteLine();
                    keepTrying = true;
                }
            }
        }
