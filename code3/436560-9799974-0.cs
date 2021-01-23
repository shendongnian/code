    private void button1_Click(object sender, EventArgs e)
    {
        // Prevent multiple button clicks
        button.Enabled = false;
        PortAccess.Output(888, 1);
        Timer timer = new Timer { Interval = 2000 };
        timer.Tick += HandleTimerTick;
        timer.Start();
    }
 
    private void HandleTimerTick(object sender, EventArgs e)
    {
        Timer timer = (Timer) sender;
        timer.Stop();
        timer.Dispose();
        button.Enabled = true;
        PortAccess.Output(888, 0);
    }
