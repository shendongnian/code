    protected override void OnStart(string[] args)
    {
        var worker = new Thread(DoWork);
        worker.IsBackground = false;
        worker.Start();
    }
    private void DoWork()
    {
        // processing goes here
    }
