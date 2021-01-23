    void MyTimer_Tick(object sender, EventArgs e)
    {
      Timer timer = (Timer)sender;
      timer.Stop();
    
      if(value)
         MyFunction();
      // if you need to continue processing Tick events after method call
      // timer.Start();
    }
