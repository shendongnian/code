    public partial class Form1 : Form
    {
        TimeSpan duration;
       
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
          duration  =  duration.Subtract(TimeSpan.FromSeconds(1)); //Subtract a second and reassign
          if (duration.Seconds < 0)
          {
              timer1.Stop();
              return;
          }
          lblHours.Text = duration.Hours.ToString();
          lblMinutes.Text = duration.Minutes.ToString();
          lblSeconds.Text = duration.Seconds.ToString();
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
