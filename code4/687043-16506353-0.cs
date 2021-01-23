    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    BackgroundWorker bw = new BackgroundWorker();
    bw.WorkerReportsProgress = true;
    bw.WorkerSupportsCancellation = true;
    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
    bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
    if (bw.IsBusy != true)
    {
       bw.RunWorkerAsync();
    }
    if (bw.WorkerSupportsCancellation == true)
    {
       bw.CancelAsync();
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
        { }
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        { }
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { }
