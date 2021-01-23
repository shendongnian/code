    private BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();
            this.worker = new BackgroundWorker
                {
                    WorkerReportsProgress = true
                };
            worker.DoWork += WorkerOnDoWork;
            worker.ProgressChanged += WorkerOnProgressChanged;
            worker.RunWorkerCompleted += delegate
                {
                    //Set the value of the progressbar to the maximum value if the work is done
                    this.progressBar1.Value = this.progressBar1.Maximum;
                };
            worker.RunWorkerAsync();
        }
        private void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Set the value of the progressbar, or increment it.
            //You can use the e.ProgressPercentage to get the value you set in the DoWork-Method
            //The e.UserState ist a custom-value you can pass from the DoWork-Method to this Method
            this.progressBar1.Increment(1);
        }
        private void WorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            // Do you stuff here. Here you can tell the backgroundworker to report the progress like.
            this.worker.ReportProgress(5);
            //You can not access properties from here, so if you want to pass a value or something else to the
            //progresschanged-method you have to use e.Argument. 
            
        }
