    public class MyHub : Hub
    {
        private static List<string> users = new List<string>();
        public override Task OnConnected()
        {
            users.Add(Context.ConnectionId);
            return base.OnConnected();
        }
    
        public override Task OnDisconnected()
        {
            users.Remove(Context.ConnectionId);
            return base.OnDisconnected();
        }
        // In your delegate check the count of users in your list.
    }
