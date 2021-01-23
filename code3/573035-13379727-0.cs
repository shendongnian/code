    var timer = new Timer(timeToWaitMs);
	timer.Elapsed += (s, e) =>
								  {
									  timer.Stop();
									  UpdateValidConnection();
								  };
    private void UpdateValidConnection()
	{
		Task.Factory.StartNew(() =>
		{
			try				
            {
				this.toolStripLabelState.Text = "Connected";
			}
			finally
			{
				RefreshDatabaseStructure();
			}
		}, CancellationToken.None, TaskCreationOptions.None, mainUiScheduler);
	}
