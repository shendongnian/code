    static void Main()
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += worker_DoWork;
        worker.RunWorkerAsync();
        // do something 
        worker.CancelAsync();
        // do something else
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        while(!worker.CancellationPending)
        {
            // do something
        }
        // perform final action
    }
