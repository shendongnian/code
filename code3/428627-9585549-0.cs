    public void StartListening() {
        IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
        IPEndPoint localEP = new IPEndPoint(ipHostInfo.AddressList[0],11000);
    
        Console.WriteLine("Local address and port : {0}",localEP.ToString());
    
        Socket listener = new Socket( localEP.Address.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp );
    
        try {
            listener.Bind(localEP);
            listener.Listen(10);
    
            while (true) {
                allDone.Reset();
    
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(
                    new AsyncCallback(SocketListener.acceptCallback), 
                    listener );
    
                allDone.WaitOne();
            }
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    
        Console.WriteLine( "Closing the listener...");
    }
    
    public void acceptCallback(IAsyncResult ar) {
        allDone.Set();
    
        Socket listener = (Socket) ar.AsyncState;
        Socket handler = listener.EndAccept(ar);
    
        // Additional code to read data goes here.  
    }
