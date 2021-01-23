    bool _stopping = false;
    Thread _backgroundThread;
    protected override void OnStart(string[] args)
    {
        _backgroundThread = new Thread(x => StartRunningThread());
        _backgroundThread.Start();
    }
    protected override void OnStop()
    {
        _stopping = true;
        _backgroundThread.Join(); // wait for background thread to exit
    }
    internal void StartRunningThread()
    {
        while (!stopping)
        {
            FileTidyUp.DeleteExpiredFile();
            Thread.Sleep(1000);
        }
    }
