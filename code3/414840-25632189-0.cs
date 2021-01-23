	static void Main(string[] args)
	{
		CancellationTokenSource cts = new CancellationTokenSource();
		
		System.Console.CancelKeyPress += (s, e) =>
		{
			e.Cancel = true;
			cts.Cancel();
		};
		MainAsync(args, cts.Token).Wait();
	}
	static async Task MainAsync(string[] args, CancellationToken token)
	{
		...
	}
