    BackgroundWorker1.WorkerReportsProgress = true;
    BackgroundWorker1.WorkerSupportsCancellation = true;
    BackgroundWorker1.DoWork += DoWorkExecuteQuery;
    BackgroundWorker1.RunWorkerCompleted += RunWorkerCompletedExecuteQuery;
    private bool QueryData()
    {
        var thinkProgBar = new ThinkingProgressBar();
        thinkProgBar.ShowCancelLink(true);
        thinkProgBar.SetThinkingBar(true);
        BackgroundWorker1.RunWorkerAsync(thinkProgBar);
        thinkProgBar.ShowDialog();
        if (thinkProgBar.Tag != null && thinkProgBar.Tag.ToString() == "Cancelled")
        {
            CancelGetDataByFilters();
            thinkProgBar.SetThinkingBar(false);
            return false;
        }
        thinkProgBar.SetThinkingBar(false);
        return true;
    }
    
    private void DoWorkExecuteQuery(object sender, DoWorkEventArgs e)
    {
        dtQueryData = null;
        e.Result = e.Argument;
        ((ThinkingProgressBar)e.Result).SetThinkingBar(true);
        dtQueryData = WEBSERVICE.GetData();  //CALL YOUR WEBSERVICE HERE
    }
            
    private void RunWorkerCompletedExecuteQuery(object sender, RunWorkerCompletedEventArgs e)
    {
        var dlg = e.Result as ThinkingProgressBar;
        if (dlg != null) {
            ((ThinkingProgressBar)e.Result).SetThinkingBar(false);
            dlg.Close();
        }
    }
