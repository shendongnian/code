    void MySuccessHandler(Socket socket) 
    { 
        // do stuff with the connected socket..        
        Console.WriteLine("Connected to {0}", socket.RemoteEndPoint);         
    }
    void MyErrorHandler(Exception e)
    {
        Console.WriteLine("Connection error {0}", e.Message);         
    }
    ...
    myConnector.ConnectToHost(MySuccessHandler, MyErrorHandler);
