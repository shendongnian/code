        public Service()
        {
            bool _IsProcessRunning = false;
            this.InitializeComponent();
            this.ServiceName = Name;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.eventLog.Source = Name;
            // initialize timer
            this.timer.Elapsed += this.TimerElapsed;
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if(!_IsProcessRunning)
            {
                DoSomething();
            }           
        }
        private void DoSomething()
        {
            try
            {
                 _IsProcessRunning = true;
                 
                 // Do our stuff here
            }
            catch(Exception Ex)
            {               
            }
            finally
            {
                 _IsProcessRunning = false;
            }
        }
