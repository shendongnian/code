    Timer myTimer = new ();
    
    //On application startup start your timer like so
    myTimer.Tick += new EventHandler(TimerEventProcessor);
    // checks every 5 seconds, Interval accepts double in milliseconds
    myTimer.Interval = 5000;
    myTimer.Start();
    // Then create a event handler for your timer Tick event
    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
        // stop your timer and restart it possibly once you received data and have updated gui
        // using task will keep it from Locking UI thread
        Task.Factory.StartNew(() => 
        { 
            //perform check to socket and update UI using some type of delegate like below
            this.Invoke((MethodInvoker)delegate {
                  TextBox.Append(Recieved Text From Socket); // runs on UI thread
             });
        }
    } 
