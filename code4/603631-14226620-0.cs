    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Stopwatch sw = new Stopwatch();
        private  int sum = 0; 
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            sw.Start();
            if (timer1.Enabled == true) { button1.Text = "stop"; sum = 0; }
            else { button1.Text = "false"; sw.Stop(); }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int hours = sw.Elapsed.Hours;
            int minutes = sw.Elapsed.Minutes;
            int seconds = sw.Elapsed.Seconds;
            label1.Text = hours + ":" ;
            if (minutes < 10) { label1.Text += "0" + minutes + ":"; }
            else { label1.Text += minutes + ":"; }
            if (seconds < 10) { label1.Text += "0" + seconds ; }
            else { label1.Text += seconds ; }
            if (seconds ==5) { sum = sum++; }
            label2.Text = Convert.ToString(sum);
        }
