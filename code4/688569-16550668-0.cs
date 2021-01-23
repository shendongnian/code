    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // update once per second, but the rate here is IRREVELANT...
            // ...and can be changed without affecting the real/game timing
            timer1.Interval = 1000; 
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        private DateTime dtReal;
        private DateTime dtGame;
        private DateTime dtReference;
        private System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
        private double TimeRatio = (TimeSpan.FromDays(365).TotalMilliseconds / 4.0) / TimeSpan.FromMinutes(1).TotalMilliseconds;
        private void button1_Click(object sender, EventArgs e)
        {
            StartTime();
        }        
        private void StartTime()
        {
            dtReference = new DateTime(2013, 1, 1);
            SW.Restart();
            timer1.Start();
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTimes();
            DisplayTimes();
        }
        private void UpdateTimes()
        {
            double elapsed = (double)SW.ElapsedMilliseconds;
            dtReal = dtReference.AddMilliseconds(elapsed);
            dtGame = dtReference.AddMilliseconds(elapsed * TimeRatio);
        }
        private void DisplayTimes()
        {
            lblReference.Text = dtReference.ToString();
            lblReal.Text = dtReal.ToString();
            lblGame.Text = dtGame.ToString();
        }
    }
