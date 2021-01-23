    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    
        if (e.Args.Length == 0)
        {
            // no argument 
            // do stuff 
        }
        else
        {
            // with arguments
            // do stuff 
        }
        this.Shutdown();
    }
