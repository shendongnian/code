    namespace SocketTestServer
    {
        class Program
        {
            static void Main(string[] args)
            {
                TcpListener lis = new TcpListener(IPAddress.Parse("127.0.0.1"), 2509);
                lis.Start();
                lis.BeginAcceptTcpClient(new AsyncCallback(acceptClient), lis);
                Console.ReadKey();
            }
            private static void acceptClient(IAsyncResult ar)
            {
                TcpListener lis = ar.AsyncState as TcpListener;
                using (TcpClient cli = lis.EndAcceptTcpClient(ar))
                {
                    using (NetworkStream ns = cli.GetStream())
                    {
                        byte[] toSend = Encoding.ASCII.GetBytes("S\r\n");
                        ns.Write(toSend, 0, toSend.Length);
                        Console.WriteLine("Client connected");
                    }
                }
            }
        }
    }
