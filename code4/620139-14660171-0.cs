        void BeginExpensiveOperation()
        {
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += ExpensiveWork;
            worker.ProgressChanged += WorkerOnProgressChanged;
            List<string> urls = new List<string> { "http://google.com" };
            worker.RunWorkerAsync(urls);
        }
        // runs in a worker thread
        void ExpensiveWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            var urls = (List<string>) e.Argument;
            foreach (var url in urls)
            {
                //TODO: do your work here synchronously
                var result = new WebClient().DownloadString(url);
                //TODO: pass the result in the userState argumetn of ReportProgress
                worker.ReportProgress(0, result); // will raise worker.ProgressChanged on the UI thread
            }
        }
        private void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
            //this executes on the UI thread
            var value = progressChangedEventArgs.UserState;
            //TODO: use result of computation to add it to the UI
            panel.Children.Add(new TextBlock {Text = value.ToString()});
        }
