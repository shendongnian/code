    TcpClient tc = null;
    try
    {
        tc = new TcpClient("192.168.1.117", 23);
        // If we get here, port is open
    } 
    catch(SocketException se) 
    {
        // If we get here, port is not open, or host is not reachable
    }
    finally
    {
       if (tc != null)
       {
          tc.Close(); 
       }
    }
    
