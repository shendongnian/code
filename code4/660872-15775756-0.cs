    private System.Windows.Forms.Timer _timer;
    private void InitTimer()
    {
        _timer = new Timer { Interval = 500 };
        _timer.Tick += _timer_Tick;
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        _timer.Stop();
        _timer.Start();
    }
    private void _timer_Tick(object sender, EventArgs e)
    {
        _timer.Stop();
        // TODO: Load file here
    }
