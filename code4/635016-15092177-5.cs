    using (SqlConnection dbConnection = new SqlConnection("Data Source=.;Initial Catalog=Database1;Integrated Security=True;MultipleActiveResultSets=True"))
	{
		dbConnection.Open();
		
		using (SqlCommand command = dbConnection.CreateCommand())
		{
			command.Parameters.Add(new SqlParameter() {Direction = ParameterDirection.ReturnValue });
			command.CommandText = "QuickTest";
			command.CommandType = CommandType.StoredProcedure;
			
			command.ExecuteNonQuery();
			rowsAffected = command.Parameters[0].Value;
		}
	}
