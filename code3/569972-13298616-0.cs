    public FrmMain()
    {    
         InitializeComponent();
         backgroundWorker1.RunWorkerAsync();
    
         var loading = new FrmLoading();
         loading.ShowDialog();
    }
    private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
    {
    	DbQuery();
    }
    
    private void BackgroundWorker1RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	Loading.Close();
    }
