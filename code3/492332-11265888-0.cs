    ListBox lbz;
    TextBox tbx;
    BackgroundWorker bgw;
    void lbz_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!bgw.IsBusy)
        {
            bgw.RunWorkerAsync(lbz.SelectedItem.ToString());
        }
    }
    
    void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = File.ReadAllText((string)e.Argument);
    }
    
    void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        tbx.Text = (string)e.Result;
    }
