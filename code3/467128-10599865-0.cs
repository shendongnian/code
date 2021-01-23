    private TimeSpan timeSpan;
    private TimeSpan oneSecond = new TimeSpan(0, 0, 1);
    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Time.Text = timeSpan.ToString();
        if (timeSpan == TimeSpan.Zero)
        {
            Time.ForeColor = Color.Red;
            timer.Stop();
            return;
        }
        timeSpan -= oneSecond;
    }
