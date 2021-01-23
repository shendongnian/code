	[Test]
	public void Testing_Reattaching_A_Detached_Entity()
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
		ISession newSession = sessionFactory.OpenSession();
		
		newSession.Lock( customer, LockMode.None );
		
		// Assert
		Assert.That( customer.Addresses.Count > 0 );
	}
