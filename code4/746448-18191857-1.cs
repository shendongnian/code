    private const int LevelMaxTime = 120;
    private DispatcherTimer t = new DispatcherTimer();
    private int Counter = LevelMaxTime;
    public MainPage()
    {
        InitializeComponent();
        t.Interval = TimeSpan.FromSeconds(1);
        t.Tick += timer_Tick;
        t.Start();
    }
    private void timer_Tick(object sender, object o)
    {
        // Do the undelayed work here, whatever that is...
        // Next, we do the delayed work, if there is any yet.
        int effectiveCount = Counter + 3;
        if (effectiveCount <= LevelMaxTime)
        {
            Time.Text = string.Format("{0}:{1}", (effectiveCount / 60), (effectiveCount % 60).ToString().PadLeft(2, ' '));
        }
        Counter--;
    }
