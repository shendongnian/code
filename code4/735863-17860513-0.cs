	while (true)
	{
		Console.WriteLine("Enter number");
		var input = Console.ReadLine();
		System.Threading.Tasks.Task.Factory.StartNew(() => 
		{
			int n;
			if(Int32.TryParse(input, out n))
				for(int i=n; i>0; i--)
				{
					Console.WriteLine(String.Format("{0} -> {1}", n, i));
					Thread.Sleep(500);
				}
		});
	}
