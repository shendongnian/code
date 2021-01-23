            public Form1()
        {
            InitializeComponent();
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true; //set to true to fire the progress-changed event
            worker.DoWork += doWork;
            worker.ProgressChanged += progressChanged;
        }
        void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage; //Progress-Value
            object userState = e.UserState; //can be used to pass values to the progress-changed-event
        }
        void doWork(object sender, DoWorkEventArgs e)
        {
            object argument = e.Argument; //Parameters for the call
            bool cancel = e.Cancel; //Boolean-Value for cancel work
            object result = e.Result; //Object for a return-value
        }
