    private int secondsToWait = 42;
    private DateTime startTime;
    private void button_Click(object sender, EventArgs e)
    {
        timer.Start();
        startTime = DateTime.Now;
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        int elapsed = (DateTime.Now - startTime).TotalSeconds;
        if (elapsed >= secondsToWait)
        {
            // run your function
            timer.Stop();
        }
        label.Text = (seconsToWait - elapsed).ToString();
    }
