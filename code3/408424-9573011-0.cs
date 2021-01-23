    Timer timer1 = new Time();
    public Form1()
        {
            InitializeComponent();
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }
