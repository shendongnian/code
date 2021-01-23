	Enumerable.Range(0, 3).AsParallel().WithDegreeOfParallelism(3).Select(n => {
		var list = new List<string>();
		list.Add(n + ": One");
		list.Add(n + ": Two");
		list.Add(n + ": Three");
		return list;
	}).Aggregate((a, b) => a.Union(b).ToList());
