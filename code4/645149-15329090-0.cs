    const int ColorStep = 16;
    private Timer _timer;
    private int _r, _g, _b;
    public frmRotateColors()
    {
        InitializeComponent();
    }
    private void btnStart_Click(object sender, EventArgs e)
    {
        _r = 0;
        _g = 0;
        _b = 0;
        _timer = new Timer { Interval = 10 };
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        if (_b >= 256) { // Terminate
            _timer.Dispose();
            this.BackColor = SystemColors.Control;
        } else {
            this.BackColor = Color.FromArgb(_r, _g, _b);
            // Get next color
            _r += ColorStep;
            if (_r >= 256) {
                _r = 0;
                _g += ColorStep;
                if (_g >= 256) {
                    _g = 0;
                    _b += ColorStep;
                }
            }
        }
    }
