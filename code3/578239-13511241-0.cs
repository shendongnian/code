    public void SubscribeToArea(string area)
    {
        Groups.Add(Context.ConnectionId, area);
        Clients.All.StartInstancePerformance();
    }
