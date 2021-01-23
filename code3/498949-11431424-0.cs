    private void onTimerTick(object sender, EventArgs e)
    {
        try
        {
            timer.Stop();
            //Do your stuff here
        }
        finally { timer.Start(); }
    }
