    aTimer = new System.Timers.Timer(10000);
    
    // Hook up the Elapsed event for the timer.
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
    // Set the Interval to 2 seconds (2000 milliseconds).
    aTimer.Interval = 2000;
    aTimer.Enabled = true;
    private void checkBox1_Checked_1(object sender, RoutedEventArgs e)
    {
      //here call timer start or stop
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(delegate
       {
         take_motions();
       });
    }
