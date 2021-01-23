    // some minor injection work
    public TestedClass(IPingFactory pingsFactory)
    {
        this.pingsFactory = pingsFactory;
    }
    public PingReply PingMachine(string machineName)
    {
        IPing ping = pingsFactory.Create();
        return ping.Send(machineName);
    }
