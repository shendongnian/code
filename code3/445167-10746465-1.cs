    public void PerformLongRunningHubOperation()
    {
        IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
 
        context.Clients.notify("Hello world");
    }
