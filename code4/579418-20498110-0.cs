    public override Task OnConnected()
    {
        Clients.Caller.sendInitMessage(...);
        return base.OnConnected();
    }
