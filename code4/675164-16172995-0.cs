        public Form2()
        {
            InitializeComponent();
            System.Windows.Forms.Timer Timer = new Timer();
            Timer.Interval = 2000;
            Timer.Enabled = true;
            Timer.Tick += new EventHandler(Timer_Tick);
        }
        private void Timer_Tick(object o, EventArgs a)
        {
                this.Close();
        }
