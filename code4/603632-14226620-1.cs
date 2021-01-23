    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int sum = 0;
        private DateTime lastUpdate;
        private Stopwatch sw = new Stopwatch();
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = string.Format("{0:00}:{1:00}:{2:00}",
                          sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds);
            if (DateTime.Now >= lastUpdate.AddSeconds(5))
            {
                sum++;
                lastUpdate = DateTime.Now;
                label2.Text = sum.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                sw.Stop(); 
                button1.Text = "stop";
            }
            else 
            {
                sum = 0;
                lastUpdate = DateTime.Now;
                timer1.Enabled = true;
                sw.Start();
                button1.Text = "Start"; 
            }
        }
