    private void timer_Tick(object sender, EventArgs e)
    {
        // ...
        timerint += 1;
        if (timerint == 5)
        {
            ((Timer)sender).Stop();
        }
    }
