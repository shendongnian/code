    using (var session = sessionFactory.OpenStatelessSession())
    using (var tx = session.BeginTransaction())
    {
 	for (int i = 0; i < count; i++)
	{
		session.Insert(yourObjects[i]);
	}
	tx.Commit();
    }
