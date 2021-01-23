    private void button2_Click(object sender, EventArgs e)
    {         
        Timer timer = new Timer { Interval = 1000, Enabled = true };
        timer.Tick += new EventHandler(PingTest);            
    }
