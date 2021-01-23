	public static void InsertObjekts(List<Objekt> objekts)
	{
		var session = SessionManager.CurrentSession;
		using (var transaction = session.BeginTransaction())
		{
			foreach(var obj in objekts)
			{
				session.SaveOrUpdate(obj);
			}
			transaction.Commit();
		}
	}
