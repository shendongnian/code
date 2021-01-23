    using System;
    using System.Threading;
    
    public class Foo
    {
        private Timer _timer;
        private readonly static TimeSpan TIME_OF_DAY = new TimeSpan(9, 30, 0);
    
        public void Main()
        {
            var now = DateTime.Now;
            var nextDt = now.Date.AddDays(1).Add(TIME_OF_DAY); 
            _timer = new Timer(TimerCallback, null, (int)nextDt.Subtract(now).TotalMilliseconds, Timeout.Infinite);
        }
    
        public void TimerCallback(object state)
        {
            try
            {
                // Reminder
            }
            finally
            {
                try
                {
                    var now = DateTime.Now;
                    var nextDt = now.Date.AddDays(1).Add(TIME_OF_DAY);
                    _timer.Change((int)nextDt.Subtract(now).TotalMilliseconds, Timeout.Infinite);
                }
                catch (ObjectDisposedException) { }
            }
        }
    }
