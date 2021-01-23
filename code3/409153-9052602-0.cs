    bwWorker.RunWorkerAsync(ofdBrowser.FileName);
    ....
    void bwWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        string filename = (string)e.Argument;
        ...
        e.Result = hash;
    }
    void bwWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        String hash = (string)e.Result;
        ...
    }
