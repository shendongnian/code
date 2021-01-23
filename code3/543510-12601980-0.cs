          static Boolean done = false;
            static void Main(string[] args)
            {
                Object s = new object();
                
    
                UdpClient server = new UdpClient(); 
    server.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true); 
    server.Client.Bind(new IPEndPoint(IPAddress.Any, 67)); 
    server.BeginReceive(new AsyncCallback(OnRecieve), s);
    
    while (!done) { Thread.Sleep(10); }
    
            }
    
            static void OnRecieve(IAsyncResult asycnResult)
            {
                Console.WriteLine("Got something");
                done = true;
    
                // Do something 
            } 
    }
