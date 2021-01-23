	BackgroundWorker backgroundWorker;
	
	private void btnAddfiles_Click(object sender, EventArgs e)
	{
		if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		{
			backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.DoWork +=
			(s3, e3) =>
			{
				StartBackgroundFileChecker(openFileDialog1.FileNames);   
			};
			
			backgroundWorker.ProgressChanged +=
			(s3, e3) =>
			{
				//example:
				this.progressBar1.Value = e.ProgressPercentage;
			};
			backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
			(s3, e3) =>
			{
				///End Here!!
			});
			backgroundWorker.RunWorkerAsync();
		}
	}
	private void StartBackgroundFileChecker(string[] files)
	{
		for (int i = 0; i < files.Length; i++)
        {
			string file = files[i];
            System.IO.Stream stream;
            try
            {
                if ((stream = openFileDialog1.OpenFile()) != null)
                {
                    using (stream)
                    {
                        ListboxFile listboxFile = new ListboxFile();
						listboxFile.OnFileAddEvent += listboxFile_OnFileAddEvent;
						//Other things...
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
			backgroundWorker.ReportProgress((i+1) * 100.0/files.Length, file);
        }
	}
