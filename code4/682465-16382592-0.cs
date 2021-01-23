            public Form1()
            {
            InitializeComponent();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += OnTimerTick;
            timer.Interval = 5000;
            timer.Start();
            }
            private void OnTimerTick(object sender, EventArgs e)
            {
            // I will fire the events here
             MessageBox.Show("5 seconds elapsed");
            }
