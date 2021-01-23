    private Timer _timer;
    private int _ticks;
    public Form1()
    {
        _timer = new Timer { Interval = 1000, Enabled = true };
        _timer.Tick += TimerTick;
        Activated += Form1_Activated;
        MouseMove += Form1_MouseMove;
        //notifyIcon1 is an icon set through the designer
        notifyIcon1.MouseMove += NotifyIcon1MouseMove;
    }
    protected void TimerTick(object sender, EventArgs e)
    {
        //After 5 seconds the app will be hidden
        if (_ticks++ == 5)
        {
            WindowState = FormWindowState.Minimized;
            Hide();
            _timer.Stop();
            _ticks = 0;
        }
    }
    protected void NotifyIcon1MouseMove(object sender, MouseEventArgs e)
    {
        WindowState = FormWindowState.Normal;
        Show();
        _ticks = 0;
        _timer.Start();
    }
    protected void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        _ticks = 0;
    }
