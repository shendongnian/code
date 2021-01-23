	[Test]
	public void Testing_A_Detached_Entity()
	{
		// Arrange
		var sessionFactory = ObjectFactory.GetInstance<ISessionFactory>();
		Customer customer = null;
		using ( ISession session = sessionFactory.OpenSession() )
		{
			using ( ITransaction tx = session.BeginTransaction() )
			{
				customer = session.Query<Customer>()
					.Where( x => x.CustomerNbr == 19 )
					.FirstOrDefault();
			}
		}
		// Act
		TestDelegate actionToPerform = () =>
		   {
			   // Looping over this child collection should throw an Exception
			   // because we no longer have an active NHibernate session
			   foreach ( var address in customer.Addresses )
			   {
			   }
		   };
		// Assert
		Assert.Throws<NHibernate.LazyInitializationException>( actionToPerform );
	}
	
