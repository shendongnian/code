    public class MyHub : Hub
    {
        internal static void SendMessage(string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.messageRecieved(message);
        }
    
        ...
    }
