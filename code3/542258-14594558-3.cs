    class MyClass
    {    
        private BackgroundWorker worker;
        public MyClass()
        {
            worker = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            Timer timer = new Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(!worker.IsBusy)
                worker.RunWorkerAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker w = (BackgroundWorker)sender;
            while(/*condition*/)
            {
                //check if cancellation was requested
                if(w.CancellationPending)
                {
                    //take any necessary action upon cancelling (rollback, etc.)
                    //notify the RunWorkerCompleted event handler
                    //that the operation was cancelled
                    e.Cancel = true; 
                    return;
                }
                //report progress; this method has an overload which can also take
                //custom object (usually representing state) as an argument
                w.ReportProgress(/*percentage*/);
                
                //do whatever You want the background thread to do...
            }
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //display the progress using e.ProgressPercentage and/or e.UserState
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                //do something
            }
            else
            {
                //do something else
            }
        }
    }
