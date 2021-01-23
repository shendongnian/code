	public void InitializeDatabase(MyContext context)
	{
		//delete any existing database, and re-create
		context.Database.Delete();
		
		var connStringBuilder = new SqlConnectionStringBuilder(context.Database.Connection.ConnectionString);
		var newDbName = connStringBuilder.InitialCatalog;
		connStringBuilder.InitialCatalog = "master";
		using(var sqlConn = new SqlConnection(connStringBuilder.ToString()))
		{
			using (var createDbCmd = sqlConn.CreateCommand())
			{
				createDbCmd.CommandText = "CREATE DATABASE " + newDbName;
				sqlConn.Open();
				createDbCmd.ExecuteNonQuery();
			}
		}
		//apply all migrations
		var dbMigrator = new DbMigrator(new Configuration());
		dbMigrator.Update();
		//seed with data
		this.Seed(context);
		context.SaveChanges();
	}
