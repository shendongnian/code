    public Form1()
    {
        InitializeComponent();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Tick += new EventHandler(timer_Tick);
        timer.Interval = 1000;
        timer.Start();
    }
