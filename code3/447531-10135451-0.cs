     protected override void OnStart(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("Service Called when Onstart");
            _timer = new Timer(10 * 60 * 1000); // every 10 minutes
            log.Debug("calling Distributor Method");
            Shell Distributor = new Shell();
            Distributor.Distribute();
           
            log.Debug("calling timer Elapsed");
           _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
           log.Debug("start the timer");
           _timer.Start();
           
        }
        protected override void OnStop()
        {
            log.Debug("stop the timer in OnStop method");
            this.ExitCode = 0;
            base.OnStop();
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
          
            log.Debug("IN Timer Elapsed method");
            try
            {
                log.Debug("IN try block and calling timer stop function");
                _timer.Stop();
                log.Debug("Distributor Method Called from try block");
                Shell Distributor = new Shell();
                Distributor.Distribute();
               
                
            }
            catch (Exception ex)
            {
                log.Debug("IN Catch Block");
                log.Debug(ex.Message); 
            }
            finally
            {
                _lastRun = DateTime.Now;
                log.Debug("IN Final Block");
                log.Debug("start the timer");
                _timer.Start();
                log.Debug("Exit the Timer Elapsed Method");
            }
