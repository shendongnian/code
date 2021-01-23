        // Create a timer
        myTimer = new System.Timers.Timer();
        // Tell the timer what top do when it elapses
        myTimer.Elapsed += new ElapsedEventHandler(myEvent);
        // Set it to go off every five seconds
        myTimer.Interval = 5000;
        // And start it        
        myTimer.Enabled = true;
        // Implement a call with the right signature for events going off
        private void myEvent(object source, ElapsedEventArgs e){}
 
