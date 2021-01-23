    //declare the timer
    private static System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
    
    
    //adds the event and event handler (=the method that will be called)
    //call this line only call once
    tmr.Tick += new EventHandler(TimerEventProcessor);
    
    //call the following line once (unless you want to change the time)
    tmr.Interval = 3000;    //sets timer to 3000 milliseconds = 3 seconds
    //call this line every time you need a 'timeout'
    tmr.Start();            //start timer           
    
    //called by timer
    private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
    {
      Console.WriteLine("3 seconds elapsed. disabling timer");
      tmr.Stop(); //disable timer
    }
