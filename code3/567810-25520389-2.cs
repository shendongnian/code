    public bool DialogResultAsync
	{
		get;
		private set;
	}
	
	public async Task<bool> ShowDialogAsync()
    {
		var cts = new CancellationTokenSource();
		// Attach token cancellation on form closing.
		Closed += (object sender, EventArgs e) =>
		{
			cts.Cancel();
		};
		Show(); // Show message without GUI freezing.
		try
		{
			// await for user button click.
			await Task.Delay(Timeout.Infinite, cts.Token);
		}
		catch (TaskCanceledException)
		{ }	
	}
	
	public void ButtonOkClick()
	{
		DialogResultAsync = true;
		Close();
	}
	
	public void ButtonCancelClick()
	{
		DialogResultAsync = false;
		Close();
	}
	
	
