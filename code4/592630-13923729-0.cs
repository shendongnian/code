    public class MessageHub: Hub
    {
        public Task AddGroups()
        {
            //add 1st group
            Groups.Add(Context.ConnectionId, "foo");
            //add 2nd group
            return Groups.Add(Context.ConnectionId, "foobar");
        }
        //this method will be called from the client
        public void Send(string message)
        {
            Clients.OthersInGroup("foobar").send(message);
        }
        //automatically join groups when client first connects
        public override Task OnConnected()
        {
            AddGroups();
            return base.OnConnected();
        }
        //rejoin groups if client disconnects and then reconnects
        public override Task OnReconnected()
        {
            AddGroups();
            return base.OnReconnected();
        }
    }
