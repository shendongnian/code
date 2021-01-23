     private void InitializeDatabaseConnectionCheckTimer()
        {
            DispatcherTimer _timerNet = new DispatcherTimer();
            _timerNet.Tick += new EventHandler(DatabaseConectionCheckTimer_Tick);
            _timerNet.Interval = new TimeSpan(_batchScheduleInterval);
            _timerNet.Start();
        }
        private void InitializeApplicationSyncTimer()
        {
            DispatcherTimer _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(AppSyncTimer_Tick);
            _timer.Interval = new TimeSpan(_batchScheduleInterval);
            _timer.Start();
        }
        private void IntializeImageSyncTimer()
        {
            DispatcherTimer _imageTimer = new DispatcherTimer();
            _imageTimer.Tick += delegate
            {
                lock (this)
                {
                    ImagesSync.SyncImages();
                }
            };
            _imageTimer.Interval = new TimeSpan(_batchScheduleInterval);
            _imageTimer.Start();
        }
