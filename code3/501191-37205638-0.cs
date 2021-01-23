	static void Main(string[] args)
	{
		bool isFirstInstance;
		using (new Mutex(false, "MUTEX: YOUR_MUTEX_NAME", out isFirstInstance))
		{
			if (!isFirstInstance)
			{
				Console.WriteLine("Another instance of the program is already running.");
				return;
			}
		
			var host = HostFactory.New(x =>
            ...
			host.Run();
		}
	}
