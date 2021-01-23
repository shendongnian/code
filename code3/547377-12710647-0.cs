        public Program()
        {
            w = new BackgroundWorker();
            w.DoWork += new DoWorkEventHandler(w_DoWork);
            w.ProgressChanged += new ProgressChangedEventHandler(w_ProgressChanged);
            w.RunWorkerCompleted += new RunWorkerCompletedEventHandler(w_RunWorkerCompleted);
            w.WorkerReportsProgress = true;
            w.WorkerSupportsCancellation = true;
            w.RunWorkerAsync();
        }
        void w_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FileInfo[] files = e.Result as FileInfo[];
            foreach (FileInfo fi in files)
            {
                //dataGrid1.Items.Add(fi);  
            }
        }
        void w_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FileInfo fi = e.UserState as FileInfo;
            //dataGrid1.Items.Add(fi);  
        }
        void w_DoWork(object sender, DoWorkEventArgs e)
        {
            var w = sender as BackgroundWorker;
            FileInfo[] files = new DirectoryInfo(
                Path.GetTempPath()).GetFiles();
            // Using ProgressChanged
            foreach (FileInfo fi in files)
            {
                w.ReportProgress(0, fi);
            }
            // Using RunWorkerCompleted
            e.Result = files;
        }
