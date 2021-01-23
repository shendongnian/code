    public partial class Form1 : Form
    {
        private Timer _timer = null;
        public Form1()
        {
            InitializeComponent();
            this.Load += OnFormLoad;
        }
    
        private void OnFormLoad(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Text = "Hide and top most on timer";
            btn.Width = 200;
            btn.Click += OnButtonClick;
            this.Controls.Add(btn);
        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            //minimize app to task bar
            WindowState = FormWindowState.Minimized;
            //timer to simulate message from another app
            _timer = new Timer();
            //time after wich form will be maximize
            _timer.Interval = 2000;
            _timer.Tick += new EventHandler(OnTimerTick);
            _timer.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            _timer.Stop();
            //message from another app came - we should 
            WindowState = FormWindowState.Normal;
            TopMost = true;
        }
    }
