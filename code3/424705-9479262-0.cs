    foreach (ClientInfo clientInfo in clientList)
    {
        if (clientInfo.token != token)
        {                           
            //Data received send to the all client but not for sender
            bool willRaiseEvent = clientInfo.token.Socket.SendAsync(e); // token.Socket.SendAsync(e);
            if (!willRaiseEvent)
            {
                ProcessSend(e);
            }
        }
    }
