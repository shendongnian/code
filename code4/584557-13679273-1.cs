        System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }
        public void BtnGenData_Click(object sender, EventArgs e)
        {
            BtnGenData.Enabled = false;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            BtnGenData.Enabled = true;
            //do what you need
        }
