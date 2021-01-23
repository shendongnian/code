    public class Run
    {
        public Timer timer;
        public Run()
        {
            var nextSecond = MilliUntilNextSecond();
            var timerTracker = new TimerTracker()
            {
                StartDate = DateTime.Now.AddMilliseconds(nextSecond),
                Interval = 1000,
                Number = 0
            };
            timer = new Timer(TimerCallback, timerTracker, nextSecond, -1);
        }
        public class TimerTracker
        {
            public DateTime StartDate;
            public int Interval;
            public int Number;
        }
        void TimerCallback(object state)
        {
            var timeTracker = (TimerTracker)state;
            timeTracker.Number += 1;
            var targetDate = timeTracker.StartDate.AddMilliseconds(timeTracker.Number * timeTracker.Interval);
            var milliDouble = Math.Max((targetDate - DateTime.Now).TotalMilliseconds, 0);
            var milliInt = Convert.ToInt32(milliDouble);
            timer.Change(milliInt, -1);
            Console.WriteLine(DateTime.Now.ToString("ss.fff"));
        }
        public static int MilliUntilNextSecond()
        {
            var time = DateTime.Now.TimeOfDay;
            var shortTime = new TimeSpan(0, time.Hours, time.Minutes, time.Seconds, 0);
            var oneSec = new TimeSpan(0, 0, 1);
            var milliDouble = (shortTime.Add(oneSec) - time).TotalMilliseconds;
            var milliInt = Convert.ToInt32(milliDouble);
            return milliInt;
        }
    }
