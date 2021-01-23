	public static IEnumerable<Marble> SearchMarbles (Marble search)
	{
		var results = marbles.AsQueryable().Where(GetComparison(search));
		return results.AsEnumerable();
	}	
