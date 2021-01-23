    DateTime start;
    DateTime final;
    
    private void start()
    {
        start = DateTime.Now;
        final = start + TimeSpan.FromHours(1);
    }
    private void counter_Tick(object sender, EventArgs e)
    {
        Time.Text = (final-start).Hours.ToString() + ":" + (final-start).Minutes.ToString() + ":" + (final-start).Seconds.ToString();    
        if (final == start)
        {
            //final code
        }        
    }
