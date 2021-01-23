	void Main()
	{
		using(new Test())
		{
			goto myLabel;
		}
	myLabel:
		"End".Dump();
	}
	class Test:IDisposable
	{
		public void Dispose()
		{
			"Disposed".Dump();
		}
	}
