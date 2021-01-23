    private bool isClosed;
    private Socket socket;
    
    void BeginReceiveNextPacket(){
    	socket.BeginReceive(..., EndReceiveNextPacket);
    }
    
    void EndReceiveNextPacket(IAsyncResult result){
    	try{
    		// By making a call to EndReceive, we allow the socket to wrap up, close internal handles and raise any exceptions if they exist.
    		socket.EndReceive(result); 
    		
    		// Now make a new call to BeginReceive after we invoked the actual call to EndReceive.
    		BeginReceiveNextPacket();
    	}
    	catch(SocketClosedException) {
    		if (closed){
    			// We forcefully closed this socket. Therefore, this exception was expected and we can ignore it.
    		}
    		else{
    			throw; // Catch an unexpected exception.
    		}
    	}
    }
    
    void Stop(){
    	isClosed = true;
    	socekt.Close();
    }
