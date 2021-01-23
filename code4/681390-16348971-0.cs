    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            int wait = 10 * 1000;
            timer = new Timer(wait);
        }
        private System.Timers.Timer timer;
        protected override void OnStart(string[] args)
        {
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            DBConnect Db = new DBConnect();
            // do amazing awesome mind blowing cool stuff
            Db.closeConnection();
            timer.Start();
        }
        protected override void OnStop()
        {
            timer.Stop();
        }
    }
