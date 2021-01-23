    private void idleTimer_Tick(object sender, EventArgs e)
    {
        if (DateTime.Now > timeOfLastActivity.AddMinutes(30))
        {
            // Do your stuff
        }
    }
