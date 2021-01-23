    partial class YourService : ServiceBase
    {
        Timer timer = new Timer();
        ...
        ...
        public YourService()
        { 
            InitializeComponent();
        }
        /// <summary>
        /// 
        protected override void OnStart(string[] args)
        {
            timer.Interval = 1000000; /*The interval of the Windows Service Cycle set this to one hour*/
            timer.Start();
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(OnElapseTime); /*fire the event after each cycle*/
        }
        private void OnElapseTime(object sender, ElapsedEventArgs e)
        {
             // HERE DO UR DATABASE QUERY AND ALL
        }
        ...
        ...
    }
