    new Thread(()=>{
    foreach (CustomerFile f in CF)
    {
        btnGo.Enabled = false;
        UpdateProgressDelegate showProgress = new UpdateProgressDelegate(UpdateProgress);
        ProcessFile pf = new ProcessFile(this, showProgress, f._FileName, txtDestFolder.Text);
        pf.DoWork();
    
    }
    }).Start();
