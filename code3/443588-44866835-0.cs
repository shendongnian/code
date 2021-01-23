     Timer aTimer = new Timer(300);
                    aTimer.Elapsed += delegate { PublishGPSData(channel, locationViewModel); };
                    // Hook up the Elapsed event for the timer. 
                    aTimer.AutoReset = true;
                    aTimer.Enabled = true;
    private void PublishGPSData(IModel channel, LocationViewModel locationViewModel)
    {
    };
