    _worker.DoWork += (sender, e) =>
    {   
    	BackgroundWorker worker = sender as BackgroundWorker;
    
    	// Do your database stuff
    
    	e.Result = databaseResult;
    }
    _timer.Elapsed += (source, e) =>
    {
    	if(!_worker.IsBusy)
    	{
    		_worker.RunWorkerAsync();
    	}
    }
