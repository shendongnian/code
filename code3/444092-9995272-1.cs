    public partial class MainPage : PhoneApplicationPage
    private BackgroundWorker bw = new BackgroundWorker();
    ...
    public MainPage()
        {
           ...
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            ...
        }
    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadData(); //LINQ2SQL queries to display DB
        }
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProBar.Value = e.ProgressPercentage;
        }
    void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            double total = 0;
            double count = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            ... 
            foreach(...)
            {
               ... Does lots of IsoStore operations / XML serialising / DB updating
               count++;
               double cntr = count / total * 100;
               worker.ReportProgress((int)cntr);
            }
        }
    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
             ...
             bw.RunWorkerAsync();
             ...
         }
