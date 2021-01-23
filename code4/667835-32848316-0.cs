	public void Edit(int id, string description, DateTime version)
	{
		using (var session = sessionFactory.OpenSession())
		using (var tx = session.BeginTransaction())
		{
			var record = session.Get<Record>(id);
			record.Version = version;
			record.Description = description;
			session.Evict(record);  //  evict the object from the session
			session.Update(record); //  NHibernate will attach the object, and will use your version
			tx.Commit();
		}
	}
