        int i;
        public Form1()
        {
            InitializeComponent();            
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += new EventHandler(timer_Tick);
            this.BackColor = Color.White;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (this.BackColor == Color.White)
                this.BackColor = Color.Black;
            else
                this.BackColor = Color.White;
        }
