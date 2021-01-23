	{
		...
		System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();
		bw.DoWork += new DoWorkEventHandler(DoWork);
		bw.RunWorkerCompleted  += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
		
		StatusLabel.Content = "Copying files...";
		
		bw.RunWorkerAsync();
		...
	}
	private void DoWork(object sender, DoWorkEventArgs e)
	{   
		AutoCopy();
	}
	private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{   
		StatusLabel.Content = "Finished";
	}
