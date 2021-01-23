    public void AcceptSignal(string methodToCall, string msg)
    {
        IClientProxy proxy = Clients.All;
        proxy.Invoke(methodToCall, msg);
    }
