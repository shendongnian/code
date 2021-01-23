    private void InitTimer()
    {
      var myTimer = new Timer();
      myTimer.Tick += new EventHandler(TimerEventProcessor);
    
      // Sets the timer interval to 3 seconds.
      myTimer.Interval = 3000;
      myTimer.Start();
    }
    
    private static void TimerEventProcessor(object sender, EventArgs e)
    {
      ToolStripStatusLabel.Visible = false;
      (sender as Timer).Stop();
    }
