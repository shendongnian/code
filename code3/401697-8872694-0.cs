    BackgroundWorker bw = new BackgroundWorker();
    public Form1()
    {
        InitializeComponent();
    
        bw.DoWork += bw_DoWork;
        bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        bw.RunWorkerAsync("MyName");
    }
    
    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Text = (string)e.Result;
    }
    
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        string name = (string)e.Argument;
        e.Result = "Hello ," + name;
    }
