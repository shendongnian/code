     public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += OnTimerTick;
            timer.Interval = 200;
            timer.Start();
            }
            string READ;
