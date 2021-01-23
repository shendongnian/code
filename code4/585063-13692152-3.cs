    public class MyHub : Hub
    {
        private static List<string> users = new List<string>();
        public override Task OnConnected()
        {
            users.Add(Context.ConnectionId);
            return base.OnConnected();
        }
        
        //SignalR Verions 1 Signature
        public override Task OnDisconnected()
        {
            users.Remove(Context.ConnectionId);
            return base.OnDisconnected();
        }
       
        //SignalR Version 2 Signature
        public override Task OnDisconnected(bool stopCalled)
        {
            users.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
        // In your delegate check the count of users in your list.
    }
