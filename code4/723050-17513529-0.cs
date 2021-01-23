    private System.Windows.Forms.Timer _timer;
    private void EMCTool_MainForm_Load(object sender, EventArgs e)
    {
        _timer = new System.Windows.Forms.Timer { Interval = 1000 };
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        if (offOn) {
            Greenlight.Show();
        } else {
            Redlight.Show();
        }
        offOn = !offOn;
    }
