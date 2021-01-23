    public partial class Form1 : Form
    {
        private TimeSpan Offset = new TimeSpan();
        private System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            UpdateTime();
        }
        public void StartButton_click(object sender, EventArgs e)
        {
            TimeSpan TS;
            if (TimeSpan.TryParse(TimerBox.Text, out TS))
            {
                Offset = TS;
            }
            else
            {
                MessageBox.Show("Invalid Starting Time. Resetting to Zero");
                Offset = new TimeSpan();
            }
            SW.Restart();
            UpdateTime();
            timer1.Start();
        }
        public void StopButton_click(object sender, EventArgs e)
        {
            SW.Stop();
            timer1.Stop();
        }
        public void ResetButton_click(object sender, EventArgs e)
        {
            Offset = new TimeSpan();
            if (SW.IsRunning)
            {
                SW.Restart();
            }
            else
            {
                SW.Reset();
            }
            UpdateTime();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();   
        }
        private void UpdateTime()
        {
            TimerBox.Text = Offset.Add(SW.Elapsed).ToString(@"hh\:mm\:ss");
        }
    }
