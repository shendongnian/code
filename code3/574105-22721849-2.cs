	using (Entities entities = new Entities())
	using (DbContextTransaction scope = entities.Database.BeginTransaction())
	{
		//Lock the table during this transaction
		entities.Database.ExecuteSqlCommand("SELECT TOP 1 KeyColumn FROM MyTable WITH (TABLOCKX, HOLDLOCK)");
		//Do your work with the locked table here...
		
		//Complete the scope here to commit, otherwise it will rollback
		//The table lock will be released after we exit the TransactionScope block
		scope.Commit();
	}
