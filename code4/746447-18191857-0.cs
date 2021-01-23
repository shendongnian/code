    private DispatcherTimer t = new DispatcherTimer();
    private int Counter = 120;
    public MainPage()
    {
        InitializeComponent();
        t.Interval = TimeSpan.FromSeconds(4);
        t.Tick += timer_Tick;
        t.Start();
    }
    private void timer_Tick(object sender, object o)
    {
        t.Interval = TimeSpan.FromSeconds(1);
        Time.Text = string.Format("{0}:{1}", (Counter / 60), (Counter % 60).ToString().PadLeft(2, ' '));
        Counter--;
    }
