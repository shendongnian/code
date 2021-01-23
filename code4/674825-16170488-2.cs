    public void Send(MyMessage message)
    {
        // Call the addMessage method on all clients            
        Clients.All.addMessage(message.Msg);
        Clients.Group(message.Group).addMessage("Group Message " + message.Msg);
    }
