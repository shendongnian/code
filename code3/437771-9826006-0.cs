	backgroundWorker1.RunWorkerAsync(); // Start the backgroundworker.
	private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
	{
		// Do you stuff here.
	}
	private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
	{
		// Report the changes.
		// NOTE: backgroundWorker1.WorkerReportsProgress = true; has to be true.
	}
	private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
	{
		// Do something when we are done.
	}
