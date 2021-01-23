    public class ScheduledJob
    {
        //Period of time the timer will be raised. 
        //Not too often to prevent the system overload.
        private readonly TimeSpan _period = TimeSpan.FromMinutes(1);
        //08:05:00 PM
        private readonly TimeSpan _targetDayTime = new TimeSpan(20, 5, 0);
        private readonly Action _action;
        private readonly Timer _timer;
        private DateTime _prevTime;
        public ScheduledJob(Action action)
        {
            _action = action;
            _timer = new Timer(TimerRaised, null, 0, _period.Milliseconds);
        }
        private void TimerRaised(object state)
        {
            var currentTime = DateTime.Now;
            if (_prevTime.TimeOfDay < _targetDayTime
                && currentTime.TimeOfDay >= _targetDayTime)
            {
                _action();
            }
            _prevTime = currentTime;
        }
    }
