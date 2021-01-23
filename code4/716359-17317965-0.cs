        private BackgroundWorker _BgWorker;
    
        public LoginFormViewModel()
        {
            _BgWorker = new BackgroundWorker();
            _BgWorker.DoWork += new DoWorkEventHandler(bgw_DoWork);
            _BgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            _BgWorker.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
        }
    void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          // write your code to check authentication
        }
    void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
          // write you code to open window
        }
    void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // write the code for busy indicator like 
        ShowProgress= true;
    }
