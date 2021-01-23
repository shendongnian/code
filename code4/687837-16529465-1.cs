    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 10 };
        System.Windows.Forms.Timer timerForStartingSlowDown = new System.Windows.Forms.Timer() { Interval = 3000 };
        bool slow = false;
        Random random = new Random();
    
        public Form1()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            timerForStartingSlowDown.Tick += new EventHandler(timerForStartingSlowDown_Tick);
            Shown += Form1_Shown;
        }
    
        void timerForStartingSlowDown_Tick(object sender, EventArgs e)
        {
            slow = true;
            timerForStartingSlowDown.Enabled = false;
        }
    
        void Form1_Shown(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timerForStartingSlowDown.Enabled = true;
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            if (timer.Interval > 350) timer.Enabled = false;
            else
            {
                if (slow) timer.Interval += 10;
                Text = random.Next(1, 100).ToString();
            }
        }
    }
