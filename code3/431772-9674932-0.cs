    // Let's say you want to wait for 5 seconds.
    System.Timers.Timer t = new System.Timers.Timer(5000);
    
    // Has the timer completed?  The callback on the web service?
    bool wsCompleted = false, timerCompleted = false, exceptionThrown = false;
    
    // Need to synchronize access to above, since it will come back on
    // different threads.
    object l = new object();
    
    // Set up the callback on the timer.
    t.Elapsed = delegate(object sender, ElapsedEventArgs e) {
        // Lock access.
        lock (l)
        {
            // Set the flag to true.
            timerCompleted = true;
    
            // If the web service has not completed and
            // the exception was not thrown, then
            // throw your exception here.
            if (!wsCompleted && !exceptionThrown) 
            {
                // The exception is being thrown.
                exceptionThrown = true;
                throw new Exception();
            }
        }
    };
    
    // Set up the callback on the web service.
    ws.GetRequestCompleted += 
        delegate(object sender,WS.GetRequestCompletedEventArgs e) {
            // Dispose of timer when done.
            using (t)
            // Lock.
            lock (l)
            {
                // The web service call has completed.
                wsCompleted = true;
    
                // If the timer completed and the exception was
                // not thrown, then do so here.
                if (timerCompleted && !exceptionThrown)
                {
                    // The exception is being thrown.
                    exceptionThrown = true;
                    throw new Exception();
                }
            }
    
            // Handle callback.
        };
    
    // Start the timer, make the web service call.
    t.Start();
    ws.GetRequest("Login","Username","Password");
