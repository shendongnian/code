    private void WaitForConnectionCallBack(IAsyncResult result)
    {
    	try
    	{
    		PipeServer.EndWaitForConnection(result);
    
    		/// ...
    		/// Some arbitrary code
    		/// ...
    	}
    	catch
    	{
    		// If the pipe is closed before a client ever connects,
            // EndWaitForConnection() will throw an exception.
        	// If we are in here that is probably the case so just return.
    		return;
    	}
    }
    
