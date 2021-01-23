    Timer _timer;
    int _counter;
    System.Threading.Thread _worker;
    public frmTimerCounter()
    {
        InitializeComponent();
        _worker = new System.Threading.Thread(() =>
        {
            while (_counter < 10000000) {
                _counter++;
                System.Threading.Thread.Sleep(20);
            }
        });
        _worker.Start();
        StartTimer();
    }
    public void StartTimer()
    {
        _timer = new System.Windows.Forms.Timer();
        _timer.Interval = 100; // 100 ms = 0.1 s
        _timer.Tick += new EventHandler(timer_Tick);
        _timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        // I used a Label for the test. Replace it by your control.
        label1.Text = _counter.ToString();
    }
