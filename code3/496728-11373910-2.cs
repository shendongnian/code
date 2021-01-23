    private void SetStatus(Color _color, string _msg)
    {
        stsStatusMsg.ForeColor = _color;
        stsStatusMsg.Text = _msg;
        timer.Start();
    }
    
    private void StatusTimer_Elapsed(object sender, EventArgs e)
    {
        stsStatusMsg.Text = "";
        timer.Stop();
    }
