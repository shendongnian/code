    while(serverRunning)
    {
        Socket clientSocket = serverSocket.Accept();
    
        // You can write your own connection handler class that automatically
        // starts a new ReceiveData thread when it gets a client connection
        ConnectionHandler chandler = new ConnectionHandler(clientSocket);
        
        // Have an on-client-disconnected event which you can subscribe to
        // and remove the handler from your list when the client is disconnected
        chandler.OnClinetDisconnectedEvent += new OnClientDisconnectedDelegate(OnClientDisconnected);
    
        mHandlerList.Add(chandler);
    
    }
    
    // When you're terminating the program, then just go through 
    // the list of active ConnectionHandlers and call some method
    // which tells them to close their connections with the clients
    // and terminates the thread.
