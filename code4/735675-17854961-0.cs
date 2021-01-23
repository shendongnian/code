    public partial class Form1 : Form
    {
        long timerCount = 0;
        string contentDirectory = "my directory";
        long lastSize = 0;
        double biggerThanRatio = 1.25;
        public Form1()
        {
            InitializeComponent();
        }
    
        private void timer2_Tick(object sender, EventArgs e)
        {
            timerCount += 1;
            TimerCount.Text = TimeSpan.FromSeconds(timerCount).ToString();
            TimerCount.Visible = true;
            if (File.Exists(Path.Combine(contentDirectory, "msinfo.nfo")))
            {
                string fileName = Path.Combine(contentDirectory, "msinfo.nfo");
                FileInfo f = new FileInfo(fileName);
                if (f.Length >= biggerThanRatio * lastSize && lastSize > 0)
                {
                    timer2.Enabled = false;
                    timer1.Enabled = true;
                }
    
                lastSize = f.Length;
            }
        }
    }
