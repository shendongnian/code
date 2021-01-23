    TimeSpan _elapsed = new TimeSpan();
    
    private void timer_Tick(object sender, EventArgs e)
    {
        _elapsed = _elasped.Add(TimeSpan.FromMinutes(1));
        labelTimer.Text = "Elapsed Time: " + _elapsed.ToString();
    }
