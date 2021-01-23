    using (SqlConnection dbConnection = new SqlConnection("Data Source=.;Initial Catalog=Database1;Integrated Security=True;MultipleActiveResultSets=True"))
	{
		dbConnection.Open();
		
		using (SqlCommand command = dbConnection.CreateCommand())
		{
			command.CommandText = "QuickTest";
			command.CommandType = CommandType.StoredProcedure;
			
			rowsAffected = command.ExecuteScalar();
		}
	}
