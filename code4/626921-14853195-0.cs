    void SomeMethod() 
    {
         ...
         client.BeginReceive(TimeSpan.FromMinutes(5), OnMessageReceived, null);
         ...
    }
    
    void OnMessageReceived(IAsyncResult iar)
    {
         var msg = client.EndReceive(iar);
         if (msg != null)
         {
             var body = msg.GetBody<MyMessageType>();
             ...
         }
    }
