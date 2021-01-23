    private System.Timers.Timer serviceTimer = new System.Timers.Timer();
    protected override void OnStart(string[] args)
    {
        InitTimer();
    }
    protected override void OnStop(string[] args)
    {
        serviceTimer.Stop();
    }
    private void InitTimer()
    {
        serviceTimer.Start();
        serviceTimer.Enabled = true;
        serviceTimer.Interval = 5000;
        serviceTimer.Elapsed += new ElapsedEventHandler(OnServiceTimerElapsed);
    }
    public void OnServiceTimerElapsed(object sender, ElapsedEventArgs args)
    {
        serviceTimer.Enabled = false;
        try
        {
            copyej();
        }
        catch(Exception ex)
        {
                     //Handle exception
        }
        finally
        {
            serviceTimer.Enabled = true;
        }
    }
