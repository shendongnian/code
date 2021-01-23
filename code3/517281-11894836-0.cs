        public Form1()
        {
            InitializeComponent();
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            var colors = new[] { Color.Aqua, Color.Gray, Color.Black,....other colors };
            var index = System.DateTime.Now.Second % colors.Length;
            this.BackColor = colors[index];
        }
