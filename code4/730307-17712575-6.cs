	public static class HackyDbSetGetContextTrick
	{ 
		public static DbContext GetContext<TEntity>(this DbSet<TEntity> dbSet)
			where TEntity: class
		{ 
			object internalSet = dbSet
				.GetType()
				.GetField("_internalSet",BindingFlags.NonPublic|BindingFlags.Instance)
				.GetValue(dbSet);
			object internalContext = internalSet
				.GetType()
				.BaseType
				.GetField("_internalContext",BindingFlags.NonPublic|BindingFlags.Instance)
				.GetValue(internalSet); 
			return (DbContext)internalContext
				.GetType()
				.GetProperty("Owner",BindingFlags.Instance|BindingFlags.Public)
				.GetValue(internalContext,null); 
		} 
	}
