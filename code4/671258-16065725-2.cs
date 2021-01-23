    System.Diagnostics.Stopwatch _sw = new System.Diagnostics.Stopwatch();
    private void start_click()
    {
        if (!_sw.IsRunning)
        {
            _sw.Start();
        }
        else
        {
            _sw.Stop();
            _sw.Reset();
        }
    }
    private void Each_Tick(object sender, EventArgs e)
    {
        lblTimerDisplay.Text = _sw.Elapsed.ToString();
    }
