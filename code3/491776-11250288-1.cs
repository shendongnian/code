    protected override void OnStart(string[] args)
    {
        var worker = new Thread(DoWork);
        worker.IsBackground = false;
        worker.Start();
        base.OnStart(args);
    }
    private void DoWork()
    {
        while (!_stopRequested)  // (set this flag in the OnStop() method)
        {
            // processing goes here
        }
    }
