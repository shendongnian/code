    System.Timers.Timer timer1= new System.Timers.Timer(1000);
    timer1.Elapsed += new ElapsedEventHandler(maximizeScreen);
    timer1.Start();
    private void maximizeScreen(object source, ElapsedEventArgs e) {
        //Do the maximizing
    
        //disable the timer
        ((System.Timers.Timer)source).Stop();
        System.Timers.Timer timer2= new System.Timers.Timer(2000);
        timer2.Elapsed += new ElapsedEventHandler(minimizeScreen);
        timer2.Start();
    }
    private void minimizeScreen(object source, ElapsedEventArgs e) {
        //Do the minimizing
        //disable the timer
        ((System.Timers.Timer)source).Stop();
    }
