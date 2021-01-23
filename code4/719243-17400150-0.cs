    ...
    Timer1.Enabled = true;
    m_StartTime = Environment.TickCount
    m_Interval = new TimeSpan(1, 20, 0).Ticks;
    ...
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        dt = dt.AddSeconds(1);
        Label1.Text = dt.ToString("H:mm:ss");    
        if (Environment.TickCount - m_StartTime > m_Interval)
        {
            Timer1.Stop();   
        }
    }
