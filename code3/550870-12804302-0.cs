	while (_backgroundWorker.IsBusy)
	{
		_backgroundWorker.CancelAsync();
		Application.DoEvents();
		System.Threading.Thread.Sleep(20);
	}
