    public void StartListening(SocketAsyncEventArgs e)
    {
        ResetBuffer(e);
        e.Completed += SocketReceive;
    
        socket.ReceiveAsync(e);
    }
