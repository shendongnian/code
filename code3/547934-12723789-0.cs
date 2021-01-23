    protected override void OnStart(string[] args)
    {
        host = new ServiceHost(typeof(TestWCF.TestService));
        host.Open(); // :-)
    }
