    public class MyHub : Hub
    {
         public void Send(string data)
         {
             // Invoke a method on the calling client
             Caller.addMessage(data);
    
             // Similar to above, the more verbose way
             Clients[Context.ConnectionId].addMessage(data);
         }
    }
