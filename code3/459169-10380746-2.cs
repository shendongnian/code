        Timer _timer;
        List<TimeSpan> timeToRun = new List<TimeSpan>();
        protected override void OnStart(string[] args) 
        {
            string timeToRunStr = "9:45;10:45;11:45;20:45";
            var timeStrArray = timeToRunStr.Split(';');
            CultureInfo provider = CultureInfo.InvariantCulture;
            foreach (var strTime in timeStrArray)
            {
                timeToRun.Add(TimeSpan.Parse(strTime));
            }
            ResetTimer();
        }
       void ResetTimer()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            TimeSpan? nextRunTime = null;
            foreach (TimeSpan runTime in timeToRun)
            {
                if (currentTime < runTime)
                {
                    nextRunTime = runTime;
                    break;
                }
            }
            if (!nextRunTime.HasValue)
            {
                nextRunTime = timeToRun[0].Add(new TimeSpan(24, 0, 0));
            }
            _timer = new Timer((nextRunTime.Value - currentTime).TotalSeconds);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            _timer.Start();
        }       
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();
            //try
            //{
            //    
            //    your code here
            //}
            ResetTimer();
        }
