	public void backup_worker_DoWork(object sender, DoWorkEventArgs e) {
		int loop = 1;
		// This should ideally not be in the DoWork, but where you setup or create the worker
		backup_worker.WorkerReportsProgress = true;
		backup_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backup_worker_RunWorkerCompleted);
		backup_worker.WorkerSupportsCancellation = true;
		// setup your scopy process
		ProcessStartInfo startinfo = new ProcessStartInfo();
		startinfo.CreateNoWindow = true;
		startinfo.UseShellExecute = false;
		startinfo.RedirectStandardError = true;
		startinfo.RedirectStandardOutput = true;
		startinfo.FileName = Environment.CurrentDirectory + "\\xcopy.exe";
		startinfo.Arguments = "/s /e /y " + '"' + source + '"' + " " + '"' + target + '"' + " ";
		Process xcopy = new Process();
		xcopy.StartInfo = startinfo;
		xcopy.ErrorDataReceived += new DataReceivedEventHandler(backup_worker_ErrorDataReceived);
		
		// start the xcopy and read the output
		xcopy.Start();
		xcopy.BeginErrorReadLine();
		string copiedFileName;
		while ((copiedFileName = xcopy.StandardOutput.ReadLine()) != null) {
			output_list.Items.Add(copiedFileName);
		}
		// we should be done when here, but doesen't hurt to wait
		xcopy.WaitForExit();
	}
	void backup_worker_ErrorDataReceived(object sender, DataReceivedEventArgs e) {
		MessageBox.Show("We have a problem. Figure what needs to be done here!");
	}
	void backup_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		if (e.Cancelled == true) {
			MessageBox.Show("Canceled!");
		} else if (e.Error != null) {
			MessageBox.Show("Error: " + e.Error.Message);
		} else {
			MessageBox.Show("Completed!");
		}
	}
