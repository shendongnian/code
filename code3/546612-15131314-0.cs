    private void Form1_Load(object sender, System.EventArgs e)
	{
	    // Start the BackgroundWorker.
	    backgroundWorker1.RunWorkerAsync();
	}
	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
	    for (int i = 1; i <= 100; i++)
	    {
		// Wait 100 milliseconds.
		Thread.Sleep(100);
		// Report progress.
		backgroundWorker1.ReportProgress(i);
	    }
	}
	private void backgroundWorker1_ProgressChanged(object sender, progress e)
	{
	    // Change the value of the ProgressBar to the BackgroundWorker progress.
	    progressBar1.Value = e.ProgressPercentage;
	    // Set the text.
	    this.Text = e.ProgressPercentage.ToString();
	}
