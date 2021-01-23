    private void BeginSend()
    {
        _clientState = EClientState.Sending;
        byte[] buffer = GetSomeData(); // gives you data for the buffer
 
        SocketAsyncEventArgs e = new SocketAsyncEventArgs();
        e.SetBuffer(buffer, 0, buffer.Length);
        e.Completed += new EventHandler<SocketAsyncEventArgs>(SendCallback);
 
        bool completedAsync = false;
 
        try
        {
            completedAsync = _socket.SendAsync(e);
        }
        catch (SocketException se)
        {
            Console.WriteLine("Socket Exception: " + se.ErrorCode + " Message: " + se.Message);
        }
 
        if (!completedAsync)
        {
            // The call completed synchronously so invoke the callback ourselves
            SendCallback(this, e);
        }
         
    }
 
