    void idleTimer_Tick (object sender, EventArgs e)
    {
        if ((DateTime.Now - lastOperationTime).TotalMinutes > 50)
        {
            ...
        }
    }
