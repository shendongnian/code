    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false; // Wait for start
            timer1.Interval = 1000; // Second
            i = 10; // Set CountDown Maximum
            label1.Text = "CountDown: " + i; // Show
            button1.Text = "Start";
        }
        public int i;
        private void button1_Click(object sender, EventArgs e)
        {
            // Switch Timer On/Off
            if (timer1.Enabled == true)
            { timer1.Enabled = false; button1.Text = "Start"; }
            else if (timer1.Enabled == false)
            { timer1.Enabled = true; button1.Text = "Stop"; }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i = i - 1;
                label1.Text = "CountDown: " + i;
            }
            else 
            { timer1.Enabled = false; button1.Text = "Start"; }
        }
    }
