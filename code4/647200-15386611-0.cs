    void DoReceive(SocketAsyncEventArgs args)
    {
        var client = (TCPClient)args.UserToken;        
        while (!client.socket.ReceiveAsync(args))
        {
            System.Threading.Thread.Sleep(10);
        }
    }
