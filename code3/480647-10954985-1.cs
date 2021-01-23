    var aTimer = new System.Timers.Timer(1000);
  
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
  
    aTimer.Interval = 1000;
    aTimer.Enabled = true;       
    //if your code is not registers timer globally then uncomment following code
    
    //GC.KeepAlive(aTimer);
  
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        draw(A, B, Pen);
    }
