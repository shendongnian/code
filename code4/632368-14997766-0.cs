    Timer timer = new Timer();
    timer.Interval = 1000;
    timer.Tick += new System.EventHandler(timer_Tick);
    timer.Start();
    
    private void timer_Tick(object sender, System.EventArgs e)
    {
        this.Text = string.Format("{0:hh:MM:ss}", DateTime.Now);
    }
