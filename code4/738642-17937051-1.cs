    ...
    aTimer = new System.Timers.Timer(10000);
    // Hook up the Elapsed event for the timer.
    aTimer.Elapsed += UpdateTimer;
    aTimer.Interval = 2000;
    aTimer.Enabled = true;
    ...
    public void delUpdate();  // This is your delegate. Put it in your MyCustomApplicationContext class.
    // This method will invoke you delegate function.
    public void UpdateTimer(object sender, ElapsedEventArgs e)
    {
        this.Invoke((delUpdate)Update);
    }
