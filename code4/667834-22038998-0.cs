    var source = @event.Session;
	var entity = @event.Entity;
	var persister = @event.Session.GetEntityPersister(@event.EntityName, entity);
	if (persister.IsVersioned)
	{
		var mode = source.GetSessionImplementation().EntityMode;
		var id = persister.GetIdentifier(entity, mode);
		var version = persister.GetVersion(entity, mode);
		var currentVersion = persister.GetCurrentVersion(id, source);
		if (!version.Equals(currentVersion))
		{
			throw new StaleObjectStateException(persister.EntityName, id);
		}
	}
