    public partial class ThinkingProgressBar : Form
    {
        private System.DateTime startTime = DateTime.Now;
        public ThinkingProgressBar()
        {
            InitializeComponent();
        }
    
        private void lblClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Tag = "Cancelled";
            this.Hide();
        }
        public void ShowCancelLink(bool show)
        {
            lblClose.Visible = show;
        }
    
        public void SetThinkingBar(bool on)
        {
            if (on)
            {
                lblTime.Text = "0:00:00";
                startTime = DateTime.Now;
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                timer1.Enabled = false;
                timer1.Stop();
            }
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            var diff = new TimeSpan();
            diff = DateTime.Now.Subtract(startTime);
            lblTime.Text = diff.Hours + ":" + diff.Minutes.ToString("00") + ":" + diff.Seconds.ToString("00");
            lblTime.Invalidate();
        }
    }
