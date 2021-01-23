	void Main()
	{
		var testList = Enumerable.Range(1,10);
		var query = testList.Where(x => 
		{
			Console.WriteLine(string.Format("Doing where on {0}", x));
			return x % 2 == 0;
		});
		Console.WriteLine("First foreach starting");
		foreach(var i in query)
		{
			Console.WriteLine(string.Format("Foreached where on {0}", i));
		}
		
		Console.WriteLine("First foreach ending");
		Console.WriteLine("Second foreach starting");
		foreach(var i in query)
		{
			Console.WriteLine(string.Format("Foreached where on {0} for the second time.", i));
		}
		Console.WriteLine("Second foreach ending");
	}
