    public void TimerProc(object state)
    {
        // ...
        var text = string.Format("{0:00}:{1:00}:{2:00}", (int)interval.TotalHours, interval.Minutes, interval.Seconds);
        minLabel.BeginInvoke(new Action<string>(
            (value) =>
            {
                minLabel.Text = value;
            }), text);
    }
