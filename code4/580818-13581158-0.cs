	private void WorkerThreadStart(object argument)
	{
		object result = null;
		Exception error = null;
		bool cancelled = false;
		try
		{
			DoWorkEventArgs e = new DoWorkEventArgs(argument);
			this.OnDoWork(e);
			if (e.Cancel)
			{
				cancelled = true;
			}
			else
			{
				result = e.Result;
			}
		}
		catch (Exception exception2)
		{
			error = exception2;
		}
		RunWorkerCompletedEventArgs arg = new RunWorkerCompletedEventArgs(result, error, cancelled);
		this.asyncOperation.PostOperationCompleted(this.operationCompleted, arg);
	}
	protected virtual void OnDoWork(DoWorkEventArgs e)
	{
		DoWorkEventHandler handler = (DoWorkEventHandler) base.Events[doWorkKey];
		if (handler != null)
		{
			handler(this, e);
		}
	}
