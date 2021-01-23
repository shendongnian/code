	Func<IEnumerable<char>, IEnumerable<IEnumerable<char>>> permutate = null;
	permutate = cs =>
	{
		var result = Enumerable.Empty<IEnumerable<char>>();
		if (cs.Any())
		{
			result = map[cs.First()].Select(c => new [] { c });
			if (cs.Skip(1).Any())
			{
				result =
					from xs in result
					from ys in permutate(cs.Skip(1))
					select xs.Concat(ys);
			}
		}
		return result;
	};
