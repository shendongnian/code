	void Main()
	{
		var source = Observable.Range(1, 4);
		
		source.Buffer(2)
			.Subscribe(i =>
		{
			Console.WriteLine("Start Processing Buffer");
			Task.WhenAll(from n in i select DoUpload(n)).Wait();
			Console.WriteLine("Finished Processing Buffer");
		});
	}
	
	private Task DoUpload(int i)
	{
		return Task.Factory.StartNew(
			() => {
				Thread.Sleep(1000);
				Console.WriteLine("Process File " + i);
			});
	}
