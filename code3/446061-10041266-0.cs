    public partial class TestTimerClass : Form
    {
        Timer timer1 = new Timer(); // Defining the timer
        public LoggedOnPopup()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick; // Make the tick event
            timer1.Interval = 1000; // Set the interval in ms (1000 ms = 1 sec)
            timer1.Start(); // Start the timer
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            timer1.Stop(); // Stop the timer (or leave it on to loop it)
        }
    }
