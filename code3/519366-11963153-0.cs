	public IObservable<int> MainEngine
	{
		get
		{
			return Observable.Defer(() =>
			{
				Random rnd = new Random();
				int maxValue = rnd.Next(20);
				System.Diagnostics.Trace.TraceInformation(
				    "Max value is: " + maxValue.ToString());
	
				return Observable.Range(0, maxValue);
			});
		}
	}
