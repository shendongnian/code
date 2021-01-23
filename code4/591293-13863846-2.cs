    System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer();
    public MainWindow()
    {
        InitializeComponent();
        tmr.Interval = TimeSpan.FromSeconds(2);
        tmr.Tick += new EventHandler(tmr_Tick);
        tmr.Start();
    }
    void tmr_Tick(object sender, EventArgs e)
    {
        tmr.Stop();
    }
