    timer.Tick += Timer_Tick;
    timer.Interval = SOME_INTERVAL;
    SomeAction();
    timer.Start();
        
    //...
    
    public void Timer_Tick(object sender, EventArgs e)
    {
      SomeAction();
    }
    public void SomeAction(){
      //...
    }
