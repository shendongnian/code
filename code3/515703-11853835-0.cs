    Timer timer;
    public void StartTimer()
    {
        timer = new Timer();
        timer.Interval = 5000; // 5 seconds
        timer.Tick += new EventHandler(timer_Tick);
        timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        Process[] p = Process.GetProcessesByName("TheApp");
        if (p.Length == 0) {
            // Restart the app if it is not running any more
            Process.Start(@"C:\Programs\Application\TheApp.exe");
        } else {
            p[0].CloseMainWindow();
        }
    }
