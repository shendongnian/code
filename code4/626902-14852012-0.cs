    protected override void OnStartup(StartupEventArgs e)
    {
        if (e.Args != null && e.Args.Count() > 0)
        {
            this.Properties["ArbitraryArgName"] = e.Args[0];
        }
     
        base.OnStartup(e);
    }
