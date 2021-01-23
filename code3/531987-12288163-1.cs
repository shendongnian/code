	listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	listener.Bind(new IPEndPoint(IPAddress.Any, 62000));
	listener.Listen(1000);
	listener.BeginAccept(OnAccept, listener);
    
    private void OnAccept(IAsyncResult ar)
    {
    	Socket listener = (Socket)ar.AsyncState;
    	Socket socket = listener.EndAccept(ar);
    	listener.BeginAccept(OnAccept, listener);
    	socket.BeginReceive(new byte[10], 0, 10, 0, (arReceive) => socket.EndReceive(arReceive), null);
    }
