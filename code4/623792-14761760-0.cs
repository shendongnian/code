    public class WaitTwoSeconds
    {
        DispatcherTimer timer = new DispatcherTimer();
        Action _onComplete;
        // This is the method to run when the timer is raised. 
        private void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            timer.Stop();
            _onComplete();
        }
        public WaitTwoSeconds(Action onComplete)
        {
            _onComplete = onComplete;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = new TimeSpan(0, 0, 2); // one second
            timer.Start();
        }
    }
