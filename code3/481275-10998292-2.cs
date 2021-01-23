    void OnUserInput(object sender, EventArgs e)
    {
        if (userResponseStopwatch != null)
        {
            userResponseStopwatch.Stop();
            
            float userResponseDuration = userResponseStopwatch.ElapsedMillisecond - 1000 / device.DisplayMode.RefreshRate - displayDeviceDelayConstant;
            userResponseStopwatch = null;
        }
    }
