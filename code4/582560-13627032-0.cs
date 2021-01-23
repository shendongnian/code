        public Form1() {
            InitializeComponent();
            DateTime now = DateTime.Now;  // avoid race
            DateTime when = new DateTime(now.Year, now.Month, now.Day, 23, 0, 0);
            timer1.Interval = (int)((when - now).TotalMilliseconds);
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e) {
            this.Close();
        }
