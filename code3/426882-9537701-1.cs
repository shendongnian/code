    void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Elapsed();
    }
    
    private void Elapsed()
    {
      if(InvokeRequired)
      {
        Invoke((Action)Elapsed);
        return;
      }
      reminderTimer.Dispose();
      this.Close();
    }
