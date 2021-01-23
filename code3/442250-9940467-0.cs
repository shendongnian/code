    public Form1()
    {
        InitializeComponent();
        BackgroundWorker worker = new BackgroundWorker();
        // init worker
        worker.DoWork += new DoWorkEventHandler(worker_DoWork);
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        Timer timer = new Timer();
        // init worker
        timer.Tick += new EventHandler(timer_Tick);
    }
    void timer_Tick(object sender, EventArgs e)
    {
        
    }
