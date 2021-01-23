    DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
    int _timeLeft = 10;
     
    public MyClass()
    {
        InitializeComponent();
        _timer.Tick += TimerTick;
        _timer.Start();
        MyTextBox.Text = _timeLeft.ToString();
    }
     
    void TimerTick(object sender, EventArgs e)
    {
        _timeLeft--;
        if (_timeLeft == 0)
        {
            _timer.Stop();
            MyTextBox.Text = null;
        }
        else
        {
            MyTextBox.Text = _timeLeft.ToString();
        }
    }
