    public partial class Form1 : Form
    {
        TimeSpan duration;
       
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
          TimeSpan ts =  duration.Subtract(TimeSpan.FromSeconds(1));
          if (ts.Seconds < 0)  // If less than zero stop timer and exit
          {
              timer1.Stop();
              return;
          }
          duration = ts;  // replace original TimeSpan with New Timespan
          lblHours.Text = ts.Hours.ToString();
          lblMinutes.Text = ts.Minutes.ToString();
          lblSeconds.Text = ts.Seconds.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!(string.IsNullOrEmpty(textBox1.Text)))
            {
                int minutes;
                bool result = int.TryParse(textBox1.Text, out minutes);
                if (result)
                {
                    duration = TimeSpan.FromMinutes(minutes);
                    timer1.Start();
                }
            }
        }
    }
