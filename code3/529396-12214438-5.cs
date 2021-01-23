    private void idleTimer_Tick(object sender, EventArgs e)
    {
        if (DateTime.Now > timeOfLastActivity.AddSeconds(30))
        {
            // Do your stuff
        }
    }
