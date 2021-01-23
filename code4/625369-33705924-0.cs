	int[] myArray = new int[] { 0, 1, 2, 3, 13, 8, 5 };
	
	var secondMax =
		myArray.Skip(2).Aggregate(
				myArray.Take(2).OrderByDescending(x => x).AsEnumerable(),
				(a, x) => a.Concat(new [] { x }).OrderByDescending(y => y).Take(2))
			.Skip(1)
			.First();
