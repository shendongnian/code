        private BackgroundWorker background;
        private void Form1_Load(object sender, EventArgs e)
        {
            background = new BackgroundWorker();
            background.WorkerSupportsCancellation = true;
            background.DoWork += BackgroundOnDoWork;
            background.RunWorkerCompleted += BackgroundOnRunWorkerCompleted;
            background.RunWorkerAsync();
        }
        private void BackgroundOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            MessageBox.Show("stop");
        }
        private void BackgroundOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            // your doWork loop should check if someone don't call background.CancelAsync();
            while (!background.CancellationPending) 
            {
                // do something
            }
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            background.CancelAsync();
        }
