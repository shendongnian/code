    class CustomBackgroundWorker : Component
    {
        private BackgroundWorker worker;
        public event ProgressChangedEventHandler FirstEvent;
        public event ProgressChangedEventHandler SecondEvent;
        public event DoWorkEventHandler DoWork
        {
            add { worker.DoWork += value; }
            remove { worker.DoWork -= value; }
        }
        public event RunWorkerCompletedEventHandler RunWorkerCompleted
        {
            add { worker.RunWorkerCompleted += value; }
            remove { worker.RunWorkerCompleted -= value; }
        }
        public CustomBackgroundWorker()
        {
            worker = new BackgroundWorker();
            worker.ProgressChanged += OnProgressChanged;
            worker.WorkerReportsProgress = true;
        }
        public void RunWorkerAsync()
        {
            worker.RunWorkerAsync();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            worker.Dispose();
        }
        private void OnProgressChanged(object o, ProgressChangedEventArgs e)
        {
            // code to handle progress change reports from the worker
        }
    }
