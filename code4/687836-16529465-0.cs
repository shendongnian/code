    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 10 };
    
        public Form1()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            Shown += Form1_Shown;
        }
    
        void Form1_Shown(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            if (timer.Interval > 350) timer.Enabled = false;
            else
            {
                timer.Interval += 10;
                Text = timer.Interval.ToString();
            }
        }
    }
