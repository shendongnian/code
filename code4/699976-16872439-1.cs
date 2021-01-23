    public partial class Form1 : Form
    {
        private Timer timer1;
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0.5D;
            timer1 = new Timer();
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.DesktopBounds.Contains(Cursor.Position))
                this.Opacity = 1D;
            else
                this.Opacity = 0.5D;
        }
    }
