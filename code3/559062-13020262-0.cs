    public IEnumerable ListEmAll() {
		return new List<int>() // just for balance, start with empty list
			.Union( English.Select(o => o.ID) )
			.Union( Spanish.Select(o => o.ID) )
			.Union( German.Select(o => o.ID) )
			.OrderBy(id => id)
			.Select(id =>
				new
				{
					ID = id,
					English = English.Where(o => o.ID == id).Select(o => o.Stuff),
					Spanish = Spanish.Where(o => o.ID == id).Select(o => o.Stuff),
					German = German.Where(o => o.ID == id).Select(o => o.Stuff)
				});
	}
