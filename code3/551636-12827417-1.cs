    [HubName("chat")]
    public class Chat : Hub
    {
        public void Send(string message)
        {
            // Call the addMessage method on all clients
            Clients.addMessage(message);
        }
    
        public void Broadcast(string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<Chat>();
            context.Clients.addMessage(message);
        }
    }
