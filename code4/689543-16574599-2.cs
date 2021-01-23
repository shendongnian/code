	void SomeMethod()
	{
		using (IUnitOfWork session = new YourUnitOfWorkImplementation())
		{
			using (var rep = new Repository<Client>(session))
			{
				var client1 = new Client("Bob");
				var client2 = new Cliente("John");
				rep.Add(client1);
				rep.Add(client2);
				var clientToDelete = rep.GetAll(c=> c.Name == "Frank").FirstOrDefaut();
				rep.Delete(clientToDelete);
				
				//Now persist the changes to the database
				session.Save();
				
			{
		{
	}
