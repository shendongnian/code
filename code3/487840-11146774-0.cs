    DateTime endTime = new DateTime(2013,01,01,0,0,0);
    private void button1_Click(object sender, EventArgs e)
    { 
        Timer t = new Timer();
        t.Interval = 500;
        t.Tick +=new EventHandler(t_Tick);
        TimeSpan ts = endTime.Subtract(DateTime.Now);
        label1.Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
        t.Start();
    }
    void  t_Tick(object sender, EventArgs e)
    {
        TimeSpan ts = endTime.Subtract(DateTime.Now);
        label1.Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
    }
