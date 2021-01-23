    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        UpdateControls(e); 
    }  
    public void UpdateControls(ProgressChangedEventArgs args)
    {
        // This assumes all your controls were created in the same thread that "this" was created
        if (this.InvokeRequired)
        {
            this.Invoke(new Action<ProgressChangedEventArgs>(UpdateControls), args);
            return;
        }
	
         // Update your controls here
         toolStripStatusLabel1.Text = args.GeneralStatus;
         toolStripProgressBar2.Value = args.ProgressStatus;
         toolStripStatusLabel3.Text = args.SpecificStatus;
    }
