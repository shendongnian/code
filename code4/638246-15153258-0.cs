	private void btnFill_Click(object sender, EventArgs e)
	{
		if (btnFill.Text == "Fill")
		{ 
			// Update the gui for the user
			// and start our long running task
			// (disable buttons etc, cause the
			// user is still able to click them!).
			picloading.BringToFront();
			bgwLoadFile.RunWorkerAsync();
		}
	}
	private void bgwLoadFile_DoWork(object sender, DoWorkEventArgs e)
	{
		// Let's call the long running task
		// and wait for it's finish.
		Fill();
	}
	private void bgwLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		// We're back in gui thread.
		// So let us show some results to the user.
		if (e.Cancelled)
		{
			// To support cancellation, the long running
			// method has to check some kind of cancel
			// flag (boolean field) to allow fast exit of it.
			labelMessage.Text = "Operation was cancelled.";
		}
		else if (e.Error != null)
		{
			labelMessage.Text = e.Error.Message;
		}
		// Hide the picture to allow the user
		// to access the gui again.
		// (re-enable buttons again, etc.)
		picLoading.SendToBack();
	}
