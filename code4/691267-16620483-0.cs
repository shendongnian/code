        private void DoBtn_Click(object sender, EventArgs e)
        {
            m_msgForm = new MsgForm();       //m_msgForm is a member variable of the class, and MsgForm is a form class with a "public static SynchronizationContext synContext"
            m_msgForm.UpdateMsg("starting ...");   //UpdateMsg is public method to show progress information
            BackgroundWorker myBackgroundWorker = new BackgroundWorker();
            myBackgroundWorker.DoWork += new DoWorkEventHandler(myBackgroundWorker_DoWork);
            myBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myBackgroundWorker_RunWorkerCompleted);
            
            myBackgroundWorker.WorkerReportsProgress = true;
            myBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(myBackgroundWorker_ProgressChanged);
            
            myBackgroundWorker.RunWorkerAsync(theBackgroundArgument);  
        }
        private void myBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            worker.ReportProgress(-1);
            //... some code
            string msgText = "doing job: " + job.Title;
            worker.ReportProgress(0, msgText);
            //... some code
            worker.ReportProgress(0, "...other text...");
            //... some code
            worker.ReportProgress(0, "...etc...");
        }
        void myBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                m_msgForm.ShowDialog();    //show as a modal dialog
            }
            else
            {
                m_msgForm.UpdateMsg(e.UserState.ToString);
            }
        }
