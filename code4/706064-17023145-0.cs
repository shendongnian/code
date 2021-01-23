    private void Form1_Load(object sender, EventArgs e)
    {
        timer.Interval = 4000;
        timer.Enabled = true; 
        timer.Tick += new EventHandler(timer1_Tick);
        timer.Start(); 
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        Ping ping = new Ping();
        PingReply pingStatus = ping.Send(IPAddress.Parse("208.69.34.231"));
        if (pingStatus.Status != IPStatus.Success)
        {
            Process.Start("C:\\WINDOWS\\system32\\rasphone.exe","-d DELTA1");
        }
    }
