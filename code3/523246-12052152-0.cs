    public void IdleDisplay(object source, ElapsedEventArgs e)
            {
                if (lbl_dyn_status.InvokeRequired)
                {
                    this.Invoke(IdleDisplay)
                }
                else
                {
                    if (minutes_left > 0)
                    {
                        minutes_left = minutes_left - 1;
                    }
    
                    lbl_dyn_status.Text = string.Format(
                        "Time until next automatic update: {0} minutes.",
                        minutes_left);
                }
            }
    
