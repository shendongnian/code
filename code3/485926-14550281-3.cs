    public partial class Form2 : Form
    {
        Timer timer = new Timer();
        public Form2()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick); // Every time timer ticks, timer_Tick will be called
            timer.Interval = (10) * (1000);             // Timer will tick every 10 seconds
            timer.Start();                              // Start the timer
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Tick");                    // Alert the user
            var time = DateTime.Now;
            label1.Text = $"{time.Hour} : {time.Minute} : {time.Seconds} : {time.Milliseconds}";
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
