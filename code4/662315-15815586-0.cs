    protected button_click(object sender, EventArgs e)
    {
        timerName = "timer1";
        EnableTimer(timerName);
    }
    private void EnableTimer(timerName)
    {
        var timer = MainForm.Controls.FirstOrDefault(z => z.Name.ToLower().Equals(timerName.ToLower());
        if (timer != null)
        {
             ((Timer)timer).Enabled = true;
        } else {
             // Timer was not found
        }
    }
