     protected override void OnStart(string[] args)
            {
                // It tells in what interval the service will run each time.
                Int32 timeInterval = Int32.Parse(Constants.TimeIntervalValue) * 60 * 60 * 1000;
                base.OnStart(args);
                TimerCallback timerDelegate = new TimerCallback(StartSendingMails);
                serviceTimer = new Timer(timerDelegate, null, 0, Convert.ToInt32(timeInterval));
            }
