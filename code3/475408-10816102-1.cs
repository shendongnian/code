    namespace SocketTestClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(IPAddress.Parse("127.0.0.1"), 2509);
                    using (NetworkStream ns = client.GetStream())
                    {
                        StreamReader sr = new StreamReader(ns);
                        Console.WriteLine(sr.ReadLine());
                        Console.ReadLine();
                    }
                }
            
            }
        }
    }
