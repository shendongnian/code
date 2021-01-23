    BackgroundWorker worker = new BackgroundWorker();
    public Form1()
    {
        InitializeComponent();
        worker.DoWork += worker_DoWork;
        worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        worker.RunWorkerAsync();//Calls worker_DoWork on a separate thread.
    }
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//Runs when worker_DoWork is completed.
    {
        //
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        //
    }
