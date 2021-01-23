    private void myTimer_Tick(object sender, EventArgs e)
    {
      if (this.InvokeRequired)
      {
         this.BeginInvoke(myTimer_Tick, sender, e);
      }
      else
      {
        this.myTimer.ISEnabled = false;
        this.doMyDelayedWork();
      }
    }
