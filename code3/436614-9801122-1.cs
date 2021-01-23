	using (var session = SessionFactory.OpenStatelessSession())
	{
		using (var tx = session.BeginTransaction())
		{
			var foo = new Foo
			{
				Id = 4567,
				// dummy Bar object that has an Id and nothing else
				Bar = new Bar {Id = 1234}
			};
			session.Insert(foo);
			tx.Commit();
		}
	}
