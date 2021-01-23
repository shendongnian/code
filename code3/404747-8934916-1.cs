    public sealed class TimerService
    {
        /// <summary>
        ///   This method registers a call back to be called after a specified period of time.
        /// </summary>
        /// <param name = "duration">The duration after which to call back</param>
        /// <param name = "callback">The method to call back</param>
        public void WhenElapsed(TimeSpan duration, Action callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            //Set up state to allow cleanup after timer completes
            var timerState = new TimerState(callback);
            var timer = new Timer(OnTimerElapsed, timerState, Timeout.Infinite, Timeout.Infinite);
            timerState.Timer = timer;
            //Start the timer
            timer.Change((int)duration.TotalMilliseconds, Timeout.Infinite);
        }
        private void OnTimerElapsed(Object state)
        {
            var timerState = (TimerState)state;
            timerState.Timer.Dispose();
            timerState.Callback();
        }
        private sealed class TimerState
        {
            public TimerState(Action callback)
            {
                Callback = callback;
            }
            public Timer Timer { get; set; }
            public Action Callback { get; private set; }
        }
    }
