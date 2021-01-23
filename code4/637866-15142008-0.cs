    public void StartListening()
    {
        // Establish the locel endpoint for the socket
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Port);
    
        // Create a TCP/IP socket
        listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
        try
        {
            // Bind the socket to the local endpoint and listen
            listener.Blocking = false;
            listener.Bind(localEndPoint);
            listener.Listen(100);
    
            // Start an asynchronous socket to listen for connections
            performListen(listener); // changed by corsiKa
        }
        catch (Exception e)
        {
            invokeStatusUpdate(0, e.Message);
        }            
    }
