    Socket socket = new Socket(AddressFamily.InterNetwork,
                               SocketType.Stream,
                               ProtocolType.Tcp);
    
    // Connect using a timeout (2 seconds)
    
    IAsyncResult result = socket.BeginConnect( sIP, iPort, null, null );
    
    bool success = result.AsyncWaitHandle.WaitOne( 2000, true );
    
    if ( !success )
    {
                // NOTE, MUST CLOSE THE SOCKET
    
                socket.Close();
                throw new ApplicationException("Failed to connect server.");
    }
    
    // Success
    //... 
