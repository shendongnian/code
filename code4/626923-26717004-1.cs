    void SomeMethod() 
    {
        ...
        client.BeginReceive(TimeSpan.FromSeconds(5), OnMessageReceived, null);
        ...
    }
    
    void OnMessageReceived(IAsyncResult iar)
    {
        if(!IsStopped)
        {
            var msg = client.EndReceive(iar);
            if (msg != null)
            {
                var body = msg.GetBody<MyMessageType>();
                ... //Do something interesting with the message
                //Remove the message from the queue
                msg.Complete();
                client.BeginReceive(TimeSpan.FromSeconds(5), OnMessageReceived, null);
            }
        }
    }
