	using (var session = SessionFactory.OpenStatelessSession())
	{
		using (var tx = session.BeginTransaction())
		{
			var bar = new Bar
			{
				Id = 1234,
				// and populate all of the other
				// properties that you would put here
			};
			session.Insert(bar);
			tx.Commit();
		}
	}
