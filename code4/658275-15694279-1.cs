    public void InitializeDatabase(MyContext context)
	{
		//delete any existing database, and re-create
		context.Database.Delete();
		var newDbConnString = context.Database.Connection.ConnectionString;
		var connStringBuilder = new SqlConnectionStringBuilder(newDbConnString);
		var newDbName = connStringBuilder.InitialCatalog;
		connStringBuilder.InitialCatalog = "master";
		//create the new DB
		using(var sqlConn = new SqlConnection(connStringBuilder.ToString()))
		{
			using (var createDbCmd = sqlConn.CreateCommand())
			{
				createDbCmd.CommandText = "CREATE DATABASE " + newDbName;
				sqlConn.Open();
				createDbCmd.ExecuteNonQuery();
			}
		}
		
		//wait up to 30s for the new DB to be fully created
		//this takes about 4s on my desktop
		var attempts = 0;
		var dbOnline = false;
		while (attempts < 30 && !dbOnline)
		{
			if (IsDatabaseOnline(newDbConnString))
			{
				dbOnline = true;
			}
			else
			{
				attempts++;
				Thread.Sleep(1000);
			}
		}
		if (!dbOnline)
			throw new ApplicationException(string.Format("Waited too long for the newly created database \"{0}\" to come online", newDbName));
		//apply all migrations
		var dbMigrator = new DbMigrator(new Configuration());
		dbMigrator.Update();
		//seed with data
		this.Seed(context);
		context.SaveChanges();
	}
	private bool IsDatabaseOnline(string connString)
	{
		try
		{
			using (var sqlConn = new SqlConnection(connString))
			{
				sqlConn.Open();
				return sqlConn.State == ConnectionState.Open;
			}
		}
		catch (SqlException)
		{
			return false;
		}
	}
