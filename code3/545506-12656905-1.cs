    class Demo{
    
       System.Timers.Timer myTimer;
    
       void InitializeTimer(){
          myTimer = new Timer(16); // elaps every 1/60 sec , appx 16 ms.
          myTimer.ElapsedEventHandler+=new ElapsedEventHandler(myTimerEventHandler); //define a handler
          myTimer.Enabled=true; //enable the timer.
       }
       void myTimerEventHandler(object sender, ElapsedEventArgs e){
         // do your thing here
       }
    }
