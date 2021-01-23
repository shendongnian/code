        Timer timer = new Timer();
        public Form2()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (10) * (1);             // Timer will tick evert 10 seconds
            timer.Enabled = true;                       // Enable the timer
            timer.Start();                              // Start the timer
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Tick");                    // Alert the user
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;
            int milSeconds = DateTime.Now.Millisecond;
            string timeString = hours + " : " + minutes + " : " + seconds + " : " + milSeconds;
            label1.Text = timeString;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
