        public static System.Windows.Threading.DispatcherTimer aTimer;
        public WindowUpdatedByTimer()
        {
            InitializeComponent();
            aTimer = new System.Windows.Threading.DispatcherTimer();
            aTimer.Tick += new EventHandler(OnTimedEvent);
            aTimer.Interval = TimeSpan.FromSeconds(5);
            aTimer.Start();
        }
        public void OnTimedEvent(object source, EventArgs e)
        {
            textBox1.Text += "SomeText ";
        }
