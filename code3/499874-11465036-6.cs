	void Main()
	{
		var list = new List<int>(){1, 2, 3, 10, 1};
		foreach(var col in list.Concat(Ext.ThrowingEnumerable<int>())
							   .SplitBetween<int>(x=>x>=10).Take(1))
		{
            Console.WriteLine("------");
			foreach(var i in col)
			    Console.WriteLine(i);
		}
	}
