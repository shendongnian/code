    System.Timers.Timer timer = new System.Timers.Timer();
    Timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
    Timer.Interval = 1000;
    private void Timer_Elapsed(object sender, EventArgs e)
    {
         LblLocalTime.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
         LblUTCTime.Text   = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss"); 
    }
