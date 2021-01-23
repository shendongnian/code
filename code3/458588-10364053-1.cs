       private Timer timer = new Timer(o => {
                                             DoSomething(); 
                                             StartTimer();
                                             });
    
       private void StartTimer()
       {
         var period = 5 * 1000; // 5 sec
         timer.Change(period, 0);
       }
