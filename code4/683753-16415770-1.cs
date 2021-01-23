    frmMain()
    {
        Worker_ProgressChanged = new Worker_ProgressChanged_Delegate(m_oWorker_ProgressChanged);
    }
    
    delegate void Worker_ProgressChanged_Delegate(object sender, ProgressChangedEventArgs e);
    Worker_ProgressChanged_Delegate Worker_ProcessChanged;
    void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(Worker_ProgressChanged, sender, e);
        }
        else
        {
            ... Add list items etc.
        }
