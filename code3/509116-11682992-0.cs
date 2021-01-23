    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        private static int i = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "10";
            timer1.Interval = 1000;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = (i--).ToString();
            if (i < 0)
            {
                timer1.Stop();
            }
        }
    }
