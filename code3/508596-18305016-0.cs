	_EagleContext.ChangeTracker.DetectChanges();
	var objectContext = ((IObjectContextAdapter)_EagleContext).ObjectContext;
	var changedEntities = objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified);
	if (_EagleContext.ChangeTracker.Entries().Any(e => e.State == EntityState.Modified)
		|| changedEntities.Count() != 0)
	{
		var dialogResult = MessageBox.Show("There are changes to save, are you sure you want to reload?", "Warning", MessageBoxButton.YesNo);
		if (dialogResult == MessageBoxResult.No)
		{
			return;
		}
	}
    // Continue with reloading...
