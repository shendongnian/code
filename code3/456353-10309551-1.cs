    public class WinService : ServiceBase
    {
    Process p = new Process();
    
    public WinService()
    {
    InitializeComponent();
    }
    
    protected override void OnStart(string[] args)
    {
    RunApp();
    }
    
    private void RunApp()
    {
    p.StartInfo.FileName = @"<path to your app>";
    p.StartInfo.Arguments = "<your params>";
    p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
    p.Start();
    }
    
    protected override void OnStop()
    {
    p.Kill();
    }
    }
