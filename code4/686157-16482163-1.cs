    string[] city = {"A","B","C","D"};
	int[] cost = {2,1,3,2,4,3};
	
	var mappings = new List<Tuple<string, string, int>>();
	var cs = new Queue<string>(city);
	var e = cost.GetEnumerator();
	while(cs.Any())
	{
		var c = cs.Dequeue();
		foreach (var o in cs)
		{
			e.MoveNext();
			mappings.Add(Tuple.Create(c, o, (int)e.Current));
		}
	}
