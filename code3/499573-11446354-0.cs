     //AsynchroneWorker 
        public void RunAsynchroneWork(DoWorkEventHandler workHandler, RunWorkerCompletedEventHandler workCompletedHandler = null)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += workHandler;
            if (workCompletedHandler != null) backgroundWorker.RunWorkerCompleted += workCompletedHandler;
            backgroundWorker.RunWorkerAsync();
        }
       public void RestartOnLoaded(object sender, DoWorkEventArgs e)
        {
        //DO SOMETHING HERE   
        }
        public void RestartOnLoaded_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
          //DO SOMETHING HERE ( after completion of RestartOnLoaded ) 
        }
