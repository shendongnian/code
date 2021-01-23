	void Main()
	{
		var prices = new Dictionary<int, int>();
		prices.Add(1, 100);
		prices.Add(2, 200);
		prices.Add(3, 100);
		prices.Add(4, 300);
	
		// Dump method is provided by LinqPad.
		prices.Reverse().Dump();
	}
