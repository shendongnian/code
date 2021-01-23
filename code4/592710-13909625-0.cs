    private bool isClosed;
    private Socket socket;
    
    void BeginReceiveNextPacket(){
    	socket.BeginReceive(..., EndReceiveNextPacket);
    }
    
    void EndReceiveNextPacket(IAsyncResult result){
    	try{
    		// by makinhg a call to end receive we allow the socket to wrap up, close internal handles and raise any exceptions if exist
    		socket.EndReceive(result); 
    		
    		// and make a new call to BeginReceive after we invoked the actual call to EndReceive
    		BeginReceiveNextPacket();
    	}
    	catch(SocketClosedException) {
    		if (closed){
    			// We forcefully closed this socket therefore this exception was expected and we can ignore it
    		}
    		else{
    			throw; // unexpected exception
    		}
    	}
    }
    
    void Stop(){
    	isClosed = true;
    	socekt.Close();
    }
