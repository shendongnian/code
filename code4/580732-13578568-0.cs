    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer(); //create it
            timer.Interval = 1000; // time interval, so it'll fire every 1 sec. (1000 ms)
            timer.Tick += new EventHandler(timer_Tick); // bind an event handler
            //...
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //do what you need
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start(); //start the timer
            // switch buttons
            button1.Enabled = false;
            button2.Enabled = true;        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop(); //stop the timer
            // switch buttons back
            button1.Enabled = true;
            button2.Enabled = false;
        }
