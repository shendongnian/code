    ///the function called in the event OutputDataReceived 
    void proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
    {
        //throw new NotImplementedException();
        if (e.Data != null)
        {
            int v = Convert.ToInt32(e.Data.ToString()); 
            // MessageBox.Show(v.ToString());
            // progress.bw.ReportProgress(v);
            this.BeginInvoke( new Action( () => {
                 this.progressBar.Value = v;
            }));
        }
    }
