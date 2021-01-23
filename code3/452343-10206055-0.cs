    protected override void OnStart(string[] args)
        {
           // SmartImportService.WebService.WebServiceSoapClient test = new WebService.WebServiceSoapClient();
           // test.Import();
             log.Info("Info - Service Started");
            _timer = new Timer(10 * 60 * 1000); // every 10 minutes??
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
    _timer.Start();
        }
    
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            log.Info("Info - Check time");
            DateTime startAt = DateTime.Today.AddHours(9).AddMinutes(48);
            if (_lastRun < startAt && DateTime.Now >= startAt)
            {
                // stop the timer 
                _timer.Stop();               
    
                try
                {
                    log.Info("Info - Import");
                    SmartImportService.WebService.WebServiceSoapClient test = new WebService.WebServiceSoapClient();
                    test.Import();
                }
                catch (Exception ex) {
                    log.Error("This is my error - ", ex);
                }
    
                _lastRun = DateTime.Now;
                _timer.Start();
            }
        }
