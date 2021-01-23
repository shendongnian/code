        public class Server
        {
            private readonly Thread _listenThread;
            private readonly TcpListener _tcpListener;
    
            public Server()
            {
                _tcpListener = new TcpListener(IPAddress.Any, 3000);
                _listenThread = new Thread(Listen);
                _listenThread.Start();
            }
    
            private void Listen()
            {
                var tcpListener = _tcpListener;
    
                if (tcpListener != null)
                {
                    tcpListener.Start();
                }
    
                while (true)
                {
                    TcpClient client = _tcpListener.AcceptTcpClient();
                    Console.Out.WriteLine("Connection Accepted");
                    Thread clientThread = new Thread(DoWork);
                    clientThread.Start(client);
                }
            }
    
            private void DoWork(object client)
            {
                TcpClient tcpClient = client as TcpClient;
    
                if (tcpClient == null)
                {
                    throw new ArgumentNullException("client", "Must pass client in");
                }
    
                using (NetworkStream clientStream = tcpClient.GetStream())
                {
                    byte[] message = new byte[1024];
    
                    while (true)
                    {
                        Console.Out.WriteLine("Waiting for message");
                        int bytesRead = clientStream.Read(message, 0, 1024);
    
                        if (bytesRead == 0)
                        {
                            break;
                        }
    
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        string received = encoder.GetString(message, 0, bytesRead);
    
                        Console.Out.WriteLine(String.Format("Read {0}", received));
                        if (received.Equals("Hello Server !"))
                        {
                            byte[] buffer = encoder.GetBytes("Hello Client!");
                            clientStream.Write(buffer, 0, buffer.Length);
                            clientStream.Flush();
                        }
                    }
                }
            }
        }
