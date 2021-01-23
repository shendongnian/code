	public void InsertOrUpdateTest(Test input)
	{
		var entity = _dbContext.Test.FirstOrDefault(t => t.ID == input.ID);
		// If that record doesn't exist, create it and add it to the DbSet<Test> Tests
		if (entity== null)
		{
			entity= new Test(id = input.ID);
			_dbContext.Tests.Add(entity);
		}
		
		// Increase the amount. For a new entity this will be equal to the amount,
		// whereas an already existing entitiy gets its current value updated.
		entity.Amount += input.Amount;
		
		_dbContext.SaveChanges();
	}
