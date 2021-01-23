        private Timer timer;
        public MyClass()
        {
            timer = new Timer();
            timer.Elapsed += TimerElapsed;
        }
        private void TimerElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (DateTime.Now.Day == DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))// is it the last day of this month
            {
                ClientStatsController.FireAll();
            }
            Thread.Sleep(TimeSpan.FromMinutes(5));
            timer.Interval = CalculateInterval();
            TimeSpan interval = new TimeSpan(0, 0, 0, 0, (int)timer.Interval);
        }
        // Helper functions
        private static TimeSpan From24HourFormat(string value)
        {
            int hours = Convert.ToInt32(value.Substring(0, 2));
            int mins = Convert.ToInt32(value.Substring(2, 2));
            return TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(mins);
        }
        private double CalculateInterval()
        {
            string runtimeValue = ConfigController.AppSettings["runTime"]; // just a simple runtime string like 0800
            double runTime = From24HourFormat(runtimeValue).TotalMilliseconds;
            if (DateTime.Now.TimeOfDay.TotalMilliseconds < runTime)
            {
                return runTime - DateTime.Now.TimeOfDay.TotalMilliseconds;
            }
            else
            {
                return (From24HourFormat("2359").TotalMilliseconds - DateTime.Now.TimeOfDay.TotalMilliseconds) + runTime;
            }
        }
        
