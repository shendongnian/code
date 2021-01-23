	Func<IEnumerable<char>, IEnumerable<IEnumerable<char>>> permutate = null;
	permutate = cs =>
	{
		if (cs.Any())
		{
			if (cs.Skip(1).Any())
			{
				return
					from y in map[cs.First()]
					from xs in permutate(cs.Skip(1))
					select (new [] { y }).Concat(xs);
			}
			else
			{
				return map[cs.First()].Select(c => new [] { c });
			}
		}
		else
		{
			return Enumerable.Empty<IEnumerable<char>>();
		}
	};
