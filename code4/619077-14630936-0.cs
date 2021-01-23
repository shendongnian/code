    void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      lock(this) {
      if (myTimer != null) //trying to stop the exception here
      {
        myTimer.Stop(); //Null Reference Exception occurs here
    
        DoStuff();
    
        myTimer.Start();
      }
      }
    }
