    private void OnTimerTick(object sender, EventArgs e)
    {
      var localTimer= Interlocked.Exchange(ref timer_, null);
      if (localTimer != null) 
      {
         localTimer.Stop();
      }
    }
