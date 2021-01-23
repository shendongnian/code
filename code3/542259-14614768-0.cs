        private System.Threading.Timer _timerThread;
        private int _period = 2000;
        public MainWindow()
        {
            InitializeComponent();
            _timerThread = new System.Threading.Timer((o) =>
             {
                 // Stop the timer;
                 _timerThread.Change(-1, -1);
                 // Process your data
                 ProcessData();
                 // start timer again (BeginTime, Interval)
                 _timerThread.Change(_period, _period);
             }, null, 0, _period);
        }
        private void ProcessData()
        {
            // do stuff;
        }
