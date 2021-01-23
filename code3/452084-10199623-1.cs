    public void FirstMethod() {
      using (System.Timers.Timer myTimer = new System.Timers.Timer())   
      { 
      myTimer.start();
      SecondMethod(myTimer);
      }
    }
    
    public void SecondMethod(System.Timers.Timer theTimer){
        //several things happen here and then
        theTimer.stop();  
    }
