    static void Main(string[] args)
            {
                const int PortNum = 5000;
                const string ServerIP = "127.0.0.1";
    
                DateTime startTime = DateTime.Now;
    
                TcpClient client = new TcpClient(ServerIP, PortNum);
                NetworkStream nwStream = client.GetStream();
    
                while (true)
                {
                    if (client.ReceiveBufferSize != 0)
                    {
                        nwStream = client.GetStream();
    
                        byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                        int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
    
                        string msg = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
    
                        Console.WriteLine("received: " + msg);
    
                        if (DateTime.Now - new TimeSpan(0, 0, 30) > startTime)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                        Console.Write("-ping-");
                    }
                }
    
    
                Console.ReadLine();
            }
