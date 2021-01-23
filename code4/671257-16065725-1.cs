    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    private void start_click()
    {
        if (!sw.IsRunning)
        {
            sw.Start();
        }
        else
        {
            sw.Stop();
            sw.Reset();
        }
    }
    private void Each_Tick(object sender, EventArgs e)
    {
        lblTimerDisplay.Text = sw.Elapsed.ToString();
    }
