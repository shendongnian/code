    private readonly ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
    private Thread _thread;
    public MyService()
    {
        InitializeComponent();
    }
    protected override void OnStart(string[] args)
    {
        _thread = new Thread(MonitorThread)
        {
            IsBackground = true
        }
    }
 
    protected override void OnStop()
    {
        _shutdownEvent.Set();
        if (!_thread.Join(5000))
        {
            _thread.Abort();
        }
    }
    private void MonitorThread()
    {
        while (!_shutdownEvent.WaitOne(5000))
        {
            Process[] pname = Process.GetProcessesByName("PipeServiceName.exe");
            if (pname.Count == 0)
            {
                 // Process has stopped. ReLaunch
                 RelaunchProcess();
            }
         }
    }
    private void RelaunchProcess()
    {
        Process p = new Process();
        p.StartInfo.FileName = "PipeServiceName.exe";
        p.StartInfo.Arguments = ""; // Add Arguments if you need them
        p.Start();
    }
