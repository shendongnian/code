    private static void ExecuteTaskCallback(object state)
    {
        ManualResetEvent canExecute = (ManualResetEvent)state;
        if (canExecute.WaitOne(0))
        {
            canExecute.Reset();
            Console.WriteLine("Doing some work...");
            //Simulate doing work.
            Thread.Sleep(3000);
            Console.WriteLine("...work completed");
            canExecute.Set();
        }
        else
        {
            Console.WriteLine("Returning as method is already running");
        }
    }
    private static void StartTaskCallbacks()
    {
        ManualResetEvent canExecute = new ManualResetEvent(true),
            stopRunning = new ManualResetEvent(false);
        int interval = 1000;
        //Periodic invocations. Begins immediately.
        Timer timer = new Timer(ExecuteTaskCallback, canExecute, 0, interval);
        //Simulate being stopped.
        Timer stopTimer = new Timer(StopTaskCallbacks, new object[]
        {
            canExecute, stopRunning, timer
        }, 10000, Timeout.Infinite);
        stopRunning.WaitOne();
        //Clean up.
        timer.Dispose();
        stopTimer.Dispose();
    }
    private static void StopTaskCallbacks(object state)
    {
        object[] stateArray = (object[])state;
        ManualResetEvent canExecute = (ManualResetEvent)stateArray[0];
        ManualResetEvent stopRunning = (ManualResetEvent)stateArray[1];
        Timer timer = (Timer)stateArray[2];
        //Stop the periodic invocations.
        timer.Change(Timeout.Infinite, Timeout.Infinite);
        Console.WriteLine("Waiting for existing work to complete");
        canExecute.WaitOne();
        stopRunning.Set();
    }
    
