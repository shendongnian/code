    public MyContext() {
	((IObjectContextAdapter)this).ObjectContext.SavingChanges += SavingChangesHandler;
    }
    private void SavingChangesHandler(object sender, EventArgs e) {
	foreach (DbEntityEntry entry in ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)) {
	_log.DebugFormat("{0} Entity: {1}", entry.State.ToString(), entry.Entity.ToString().Contains("DynamicProxies") ? entry.Entity.GetType().BaseType.Name : entry.Entity.ToString());
	if (entry.State != EntityState.Deleted) {
       	    var changedProperties = entry.CurrentValues.PropertyNames.Where(p => entry.Property(p).IsModified);
	    changedProperties.ToList().ForEach(p => _log.DebugFormat("{0} changed from {1} to {2}", p, entry.Property(p).OriginalValue, entry.Property(p).CurrentValue));
		//TODO: handle complex properties
					}
				}
		}
