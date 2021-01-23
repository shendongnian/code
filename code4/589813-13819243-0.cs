    Timer time1 = new Timer();
    time1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    time1.Interval = 30000; // 30 secs
    ...
    time1.Enabled = true; // Start the timer
    message.ShowDialog();
    
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // Close your Form
        message.Close();
        // Maybe you could set a variable, that indicates you, that the timer timed out
    
    }
