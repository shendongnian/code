        TimeSpan TimeLeft = new TimeSpan();
        DateTime voteTime = Properties.Settings.Default.voteTime;      
        public Form3()
        {
            InitializeComponent();
            TimeLeft = voteTime - DateTime.Now;
            label1.Text = TimeLeft.ToString(@"hh\:mm");
            //This value is in milliseconds.  Adjust this for a different time 
            //interval between updates
            timer1.Interval = 60000;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLeft = voteTime - DateTime.Now;
            label1.Text = TimeLeft.ToString(@"hh\:mm");
        }
