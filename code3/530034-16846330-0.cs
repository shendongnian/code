           TcpListener serverSocket = new TcpListener ( serverAddr, serverPort );
           
           ...
           try
           {
               TcpClient serverClient = serverSocket.AcceptTcpClient ();
               // do something
           }
           catch (SocketException e)
           {
               if ((e.SocketErrorCode == SocketError.Interrupted))
               // a blocking listen has been cancelled
           }
    
           ...
           // somewhere else your code will stop the blocking listen:
           serverSocket.Stop();
           
