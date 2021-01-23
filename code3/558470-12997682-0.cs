    public Form1()
    {
        InitializeComponent();
        Timer timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += new EventHandler(Tick);
    }
    private void Tick(object sender, EventArgs e)
    { ... }
