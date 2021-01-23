    private Timer _timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 10000;
            _timer.Tick += new EventHandler(_timer_Tick);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                if(_timer.Enabled)
                    _timer.Stop();
            }
            else
            {
                checkBox1.Checked = true;
                if (!_timer.Enabled)
                    _timer.Start();
            }
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            //do something here
            throw new NotImplementedException();
        }
