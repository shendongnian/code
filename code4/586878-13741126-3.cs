    private void TimerTick(object sender, EventArgs e)
    {
        //Disabling the timer will ensure the `TimerTick` method will not try to run
        //while we are processing the files. This covers the case where processing takes
        //longer than 2 minutes.
        timer.Enabled = false;
        
        //Run the first block of code in my answer.
        
        //Reenabling the timer will start the polling back up.
        timer.Enabled = true;
    }
