    Socket clientSocket;
    System.Net.IPEndPoint clientEndPoint;
    System.Net.Sockets.NetworkStream networkStream;
    IAsyncResult beginAcceptAsyncResult;
    System.Threading.WaitHandle []waitHandleArray;
    int waitHandleSignalled;
    
    System.Net.IPEndPoint listenEndpoint = new System.Net.IPEndPoint("127.0.0.1", 45000); //make sure port is free (check with cmd: netstat -an)
    System.Net.Sockets.TcpListener listener = new System.Net.Sockets.TcpListener(listenEndpoint);
    
    waitHandleArray = new System.Threading.WaitHandle[1];
    
    listener.Start();
    
    do
    {
    	try
    	beginAcceptAsyncResult = listener.BeginAcceptSocket(null, null);
    	waitHandleArray[0] = beginAcceptAsyncResult.AsyncWaitHandle;
    	waitHandleSignalled = System.Threading.WaitHandle.WaitAny(waitHandleArray);
    	
    	if (waitHandleSignalled != 0)
    	{
    		clientSocket = _TCPListener.EndAcceptSocket(BeginAcceptAsyncResult);
    		
    		clientEndPoint = clientSocket.RemoteEndPoint as System.Net.IPEndPoint;
    		
    		networkStream = new System.Net.Sockets.NetworkStream(clientSocket, true);
    		
    		//do more with NetworkStream...
    	}
    }
    //...
    //...
