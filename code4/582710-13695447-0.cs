        // _dispatcherTimer is probably a class level variable.
        DispatcherTimer _dispatcherTimer;
        // How often
        uint _DoSomethingInterval = 500;
        // Set up a DispatchTimer
        _dispatcherTimer = new DispatcherTimer();
        _dispatcherTimer.Tick += DoSomething;
        // If you like lambdas, do this
        //_dispatcherTimer.Tick += (sender, object ) => 
        // { Debug.WriteLine("time passed so do something"); }
        _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, (int)_desiredReportInterval);
        // The callback for the timer
        private void DoSomething(object sender, object args)
        {
            Debug.WriteLine("time passed so do something"); 
        }
