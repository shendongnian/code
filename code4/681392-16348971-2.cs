    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            int wait = 10 * 1000;
            timer = new Timer(wait);
            timer.Elapsed += timer_Elapsed;
            // We don't want the timer to start ticking again till we tell it to.
            timer.AutoReset = false;
        }
        private System.Timers.Timer timer;
        protected override void OnStart(string[] args)
        {
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                try
                {
                    DBConnect Db = new DBConnect())
                
                    // do amazing awesome mind blowing cool stuff
                }
                finally
                {
                    Db.closeConnection(); //We put this in a finally block so it will still happen, even if an exception is thrown.
                }
                timer.Start();
             }
             catch(SomeNonCriticalException ex)
             {
                 MyExecptionLogger.Log(ex, Level.Waring); //Log the exception so you know what went wrong
                 timer.Start(); //Start the timer for the next loop
             }
             catch(Exception ex)
             {
                 MyExecptionLogger.Log(ex, Level.Critical); //Log the exception so you know what went wrong
                 this.Stop(); //Stop the service
             }
        }
        protected override void OnStop()
        {
            timer.Stop();
        }
    }
