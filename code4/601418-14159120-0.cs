    public partial class WaitWindow : Form
    {
        System.Windows.Forms.Timer timer;
        public WaitWindow(int interval)
        {
            InitializeComponent();
            this.Shown += new EventHandler(WaitWindow_Shown);
            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += new EventHandler(timer_Tick);
        }
        void WaitWindow_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
