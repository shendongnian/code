    private void InitializeTimer()
    {
        counter = 0;
        t.Interval = 750;
        t.Enabled = true;
        timer1_Tick(null, null);
        t.Tick += new EventHandler(timer1_Tick);
    }
