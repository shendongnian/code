    foreach (var item in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted)
		.Where(entry => entry.Entity is ITracksLastModified)
		.Select(entry => entry.Entity as ITracksLastModified))
	{
		item.LastModified = DateTime.UtcNow;
	}
