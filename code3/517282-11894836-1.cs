        public Form1()
        {
            this.BackColor = Color.Green;
            InitializeComponent();
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            var colors = new[] { Color.Yellow, Color.Green};
            var index = DateTime.Now.Second % colors.Length;
            this.BackColor = colors[index];
        }
