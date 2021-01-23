        public Form1()
        {
            InitializeComponent();
            var timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 10000; //10 seconds
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (your_function_call())
            {
                netConnect.BackColor = Color.Green;
            }
            else
                netConnect.BackColor = Color.Red;
        }
