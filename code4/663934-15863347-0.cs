    lst = lst.Select(t => Tuple.Create(
    	t.Item1,
    	t.Item2.Select(it => Tuple.Create(it.Item1, it.Item2, Transform(it.Item3))).ToList(),
    	t.Item3,
    	t.Item4,
    	t.Item5
    )).ToList();
