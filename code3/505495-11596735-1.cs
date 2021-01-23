	var accumulator = new List<KeyValuePair<string, List<string>>>()
	{
		new KeyValuePair<string, List<string>>(
		    list.First().type,
		    new List<string>()),
	};
	var results = list.Aggregate(accumulator, (a, x) =>
	{
		if (a.Last().Key == x.type)
		{
			a[a.Count - 1].Value.Add(x.value);
		}
		else
		{
			a.Add(new KeyValuePair<string, List<string>>(
				x.type,
				new List<string>(new [] { x.value, })));
		}
		return a;
	});
