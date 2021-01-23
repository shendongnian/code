     private Timer _timer;
        DateTime[] timeToRun;
        protected override void OnStart(string[] args)
        {
            string timeToRunStr = "9:45;10:45;11:45;20:45";
            var timeStr = timeToRunStr.Split(';');
            ResetTimer();
        } 
        void ResetTimer()
        {          
            var currentTime = DateTime.Now;
            DateTime nextRunTime =  timeToRun[0];
            foreach (DateTime runTime in timeToRun)
            {
                if (currentTime < runTime)
                {
                    nextRunTime = runTime;
                    break;
                }
            }
            _timer = new Timer((nextRunTime - currentTime).TotalSeconds);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            _timer.Start();
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop(); 
            try
            {
                SmartImportService.WebService.WebServiceSoapClient test = new WebService.WebServiceSoapClient();
                test.Import();
            }
            ResetTimer();
        }
