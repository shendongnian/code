    using (SqlConnection dbConnection = new SqlConnection("Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True;MultipleActiveResultSets=True"))
	{
		dbConnection.Open();
		
		using (SqlCommand command = dbConnection.CreateCommand())
		{
			command.CommandText = "QuickTest";
			command.CommandType = CommandType.StoredProcedure;
			
			Console.WriteLine(command.ExecuteNonQuery());
		}
	}
