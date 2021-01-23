	var session = StructureMap.ObjectFactory.GetInstance<ISession>();
	using ( var tx = session.BeginTransaction() )
	{
		try
		{
			// Do your work here
			tx.Commit();
		}
		catch ( Exception )
		{
			tx.Rollback();
			throw;
		}
	}
