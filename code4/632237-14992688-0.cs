    private void DispatcherTimer_Tick(object sender, EventArgs e) 
    {
        if ((DateTime.Now - lastWorkDoneTime).Minutes > numOfMinutesInterval)
        {
            Task.Factory.StartNew(DoIntensiveWork());
            lastWorkDoneTime = DateTime.Now;
        }
    }
