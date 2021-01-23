    BackgroundWorker bw1 = new BackgroundWorker();//To rebuild catalog.
    BackgroundWorker bw2 = new BackgroundWorker();//To generate text.
    
    public Form1()
    {
        InitializeComponent();
    
        bw1.DoWork += bw1_DoWork;
        bw1.RunWorkerCompleted += bw1_RunWorkerCompleted;
        bw2.DoWork += bw2_DoWork;
        bw2.RunWorkerCompleted += bw2_RunWorkerCompleted;
    
        bw1.RunWorkerAsync();//Start new thread. - Rebuild catalog.
    }
    
    void bw1_DoWork(object sender, DoWorkEventArgs e)
    {
        //Rebuild catalog.
    }
    
    void bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        bw2.RunWorkerAsync();//Generate text.
    }
    
    void bw2_DoWork(object sender, DoWorkEventArgs e)
    {
        //Generate text.
    }
    
    void bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        //Whatever...
    }
