	private void btnPause_Click(object sender, EventArgs e)
	{
		waitHandle.Reset(); // Need to pause the background thread
	}
	private void btnContinue_Click(object sender, EventArgs e)
	{
		waitHandle.Set(); // Need to continue the background thread
	}
