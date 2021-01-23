        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o => readFile(e));
        }
        public void readFile(System.IO.FileSystemEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
                                                   {
                                                       label1.Text = "Processing...";
                                                       this.Refresh(); //you shouldn't need this
                                                   }));
            //your long running read/processing... doing something event args
            this.BeginInvoke(new MethodInvoker(() =>
                                                   {
                                                       label1.Text = "Completed...";
                                                       this.Refresh();
                                                       idx = (int) e.Result;
                                                   }));
        }
