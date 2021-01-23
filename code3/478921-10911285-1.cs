    protected override void OnStart(string[] args)
    {
        try
        {
            MyWCFService.ServiceHandle = this.ServiceHandle;
            host = new ServiceHost(typeof(MyWCFService), new Uri(@"net.pipe://localhost/MyService"));
            host.Open();
        }
        catch (Exception e)
        {
            EventLog.WriteEntry("MyWCFService:", e.Message);
        }
    }
