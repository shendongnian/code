        System.Timers.Timer timer;
        static void Main(string[] args)
        {
            ServiceBase.Run(new Program());
        }
        public Program()
        {
            this.ServiceName = "DB Sync";
        }
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            InitializeTimer();
        }
        protected override void OnStop()
        {
            base.OnStop();
        }
        protected void InitializeTimer()
        {
            try
            {
                if (timer == null)
                {
                    timer = new System.Timers.Timer();
                    timer.Enabled = true;
                    timer.AutoReset = true;
                    timer.Interval = 60000 * 1;
                    timer.Enabled = true;
                    timer.Elapsed += timer_Elapsed;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
            }
        }
        protected void timer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            TimerTick();
            timer.Interval = 60000 * Convert.ToDouble(ConfigurationManager.AppSettings["TimerInerval"]);
        }
        private void TimerTick()
        {
            try
            {
               // Query the DB in this place.
            }
            catch (Exception ex)
            {
               
            }
        }
    }
