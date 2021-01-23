    public partial class TestTimerClass : Form
    {
        Timer timer1 = new Timer(); // Make the timer available for this class.
        public TestTimerClass()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick; // Assign the tick event
            timer1.Interval = 1000; // Set the interval of the timer in ms (1000 ms = 1 sec)
            timer1.Start(); // Start the timer
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            timer1.Stop(); //  Stop the timer (remove this if you want to loop the timer)
        }
    }
