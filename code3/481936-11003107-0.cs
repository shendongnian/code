	class Program
	{
		static void Main(string[] args)
		{
			DatabaseContextFactory.CreateSchema();
			var user = new User();
			user.Roles = new List<Role>();
			var role = new Role();
			user.Roles.Add(role);
			ISessionFactory sessionFactory = DatabaseContextFactory.CreateSessionFactory();
			using (ISession session = sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					session.SaveOrUpdate(role);
					session.SaveOrUpdate(user);
					transaction.Commit();
				}
			}
		}
	}
