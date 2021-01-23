    Timer timer1 = new Timer();
    timer1.Interval = 3000;
    timer1.Enabled = true;
    timer1.Tick += new System.EventHandler(timer1_Tick);
    void timer1_Tick(object sender, EventArgs e)
    {
        timer1.Stop();  // or timer1.Enabled = false;
    }
