	public static void AddRangeFast<T>(this DbContext context, IEnumerable<T> items) where T : class
	{
		var detectChanges = context.Configuration.AutoDetectChangesEnabled;
		try
		{
			context.Configuration.AutoDetectChangesEnabled = false;
			var set = context.Set<T>();
			foreach (var item in items)
			{
				set.Add(item);
			}
		}
		finally
		{
			context.Configuration.AutoDetectChangesEnabled = detectChanges;
		}
	}
