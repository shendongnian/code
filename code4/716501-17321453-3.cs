	using (var dbContext = new MyDbContext())
	{
		IQueryable<Table1Item> query = dbContext.Table1;
		
		if (condition1)
		{
			query = query.Where(c => c.Col1 == 0);
		}
		if (condition2)
		{
			query = query.Where(c => c.Col2 == 1);
		}
		if (condition3)
		{
			query = query.Where(c => c.Col3 == 2);
		}	
		
		PrintResults(query);
	}
