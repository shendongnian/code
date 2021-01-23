    private DateTime? lastClickTime;
    public void MyUpDown_ValueChanged(object sender, EventArgs e)
    {
        if (lastClickTime != null && DateTime.Now.Subtract(lastClickTime.Value).Seconds > someInterval)
        {
            // Do the work
        }
        
        lastClickTime = DateTime.Now
    }
