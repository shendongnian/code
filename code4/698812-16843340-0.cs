     private readonly static Lazy<IHubConnectionContext> _clients = new Lazy<IHubConnectionContext>(() => GlobalHost.ConnectionManager.GetHubContext<MyHostHub>().Clients);
     private IHubConnectionContext Clients
     {
        get { return _clients.Value; }
     }
     public void SendMessage(string message)
     {
        Clients.All.triggerMessage(message);
     }
