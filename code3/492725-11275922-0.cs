    public class MyHub : Hub, IDisconnect
    {
        public Task Join()
        {
            return Groups.Add(Context.ConnectionId, "foo");
        }
    
        public Task Send(string message)
        {
            return Clients["foo"].addMessage(message);
        }
    
        public Task Disconnect()
        {
            return Clients["foo"].leave(Context.ConnectionId);
        }
    }
