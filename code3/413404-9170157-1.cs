    private void SendCallback(object sender, SocketAsyncEventArgs e)
    {
        if (e.SocketError == SocketError.Success)
        {
            // You may need to specify some type of state and 
            // pass it into the BeginSend method so you don't start
            // sending from scratch
            BeginSend();
        }
        else
        {
            Console.WriteLine("Socket Error: {0} when sending to {1}",
                   e.SocketError,
                   _asyncTask.Host);
        }
    }
