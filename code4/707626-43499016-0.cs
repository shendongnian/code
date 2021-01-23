    public virtual void AddRangeFastAndCommit(IEnumerable<T> entities)
	{
		MyDbContext localContext = new MyDbContext(_context.Options);
		localContext.ChangeTracker.AutoDetectChangesEnabled = false;
		foreach (var entity in entities)
		{
			localContext.Add(entity);
		}
		localContext.SaveChanges();
		localContext.Dispose();
	}
