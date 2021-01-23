    public class MyPresenter
    {
        private BackgroundWorker _bw;
        private IView _view;
    
        public MyPresenter(IView Iview)
        {
            _view = Iview;
            _bw = new BackgroundWorker();
            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.ProgressChanged += new ProgressChangedEventHandler(_bw_ProgressChanged);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_Completed);
        }
    
        public void StartTimeConsumingJob()
        {
            _bw.RunWorkerAsync();
        }
    
        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Time consuming operation Do the job
            Thread.Sleep(1000);
            _bw.ReportProgress(50);
            Thread.Sleep(2000);
            if(_bw.CancellationPending)
            {
                e.Result = false;
            }
        }
    
        public bool IsBusy()
        {
            return _bw.IsBusy;
        }
    
        public void Cancel()
        {
            _bw.CancelAsync();
        }
    
        private void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _view.ShowProgress(e.ProgressPercentage);
        }
    
        private void _bw_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if((bool)e.Result)
            _view.ShowProgress(100);
            else
                _view.ShowProgress(0);
    
            _bw.Dispose();
        }
    }
