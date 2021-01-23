    public Form1()
    {
        InitializeComponent();
        backgroundWorker1.RunWorkerAsync();
        MessageBox.Show(@"Please wait while the database is being backed up", @"This might take several days.");
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        Debug.WriteLine("Running"); //Execute a task
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Debug.WriteLine("Ended"); //Dispose of any objects you'd like (close yor form etc.)
    }
