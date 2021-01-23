    public partial class MyForm : Form
    {
        private readonly Timer _timer = new Timer();
        public MyForm()
        {
            InitializeComponent();
            _timer.Interval = 500;
            _timer.Tick += TimerTick;
            _timer.Enabled = true;
        }
        void TimerTick(object sender, EventArgs e)
        {
            _labelAzimuth.Text = T.Azimuth.ToString();
            _labelAltitude.Text = T.Altitude.ToString();
            _labelDeclination.Text = T.Declination.ToString();
            _labelRightAscension.Text = T.RightAscension.ToString();
        }
    }
