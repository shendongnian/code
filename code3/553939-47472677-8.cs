    public partial class MyServiceProject: ServiceBase
    {
    private Timer _timer;
    public MyServiceProject()
    {
        InitializeComponent();
    }
    private void SetupProcessingTimer()
    {
        _timer = new Timer();
        _timer.AutoReset = true;
        double interval = Settings.Default.Interval;
        _timer.Interval = interval * 60000;
        _timer.Enabled = true;
        _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    }
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // begin your service work
        MakeSomething();
    }
    protected override void OnStart(string[] args)
    {
        SetupProcessingTimer();
    }
    ...
    }
