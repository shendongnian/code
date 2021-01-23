    DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(200) };
    int _timeLeft = 50;
    Stopwatch watch = new Stopwatch();
    public MainPage()
    {
    InitializeComponent();
    _timer.Tick += TimerTick;
    _timer.Start();
    textBlock1.Text = _timeLeft.ToString();
    watch.Start();
    }
    void TimerTick(object sender, EventArgs e)
    {
        
        if ((_timeLeft - (int)watch.Elapsed.TotalSeconds) <= 0)
        {
            watch.Stop();
            _timer.Stop();
            textBlock1.Text = null;
        }
        else
        {
            textBlock1.Text = (_timeLeft - (int)watch.Elapsed.TotalSeconds).ToString();
        }
    }
