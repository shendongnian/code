    using (SqlConnection dbConnection = new SqlConnection("Data Source=.;Initial Catalog=Database1;Integrated Security=True;MultipleActiveResultSets=True"))
	{
		dbConnection.Open();
		
		using (SqlTransaction tran = dbConnection.BeginTransaction())
		{
			using (SqlCommand command = dbConnection.CreateCommand())
			{
				command.Transaction = tran;
				
				try
				{
					command.Parameters.Add(new SqlParameter() {Direction = ParameterDirection.ReturnValue });
					command.CommandText = "QuickTest";
					command.CommandType = CommandType.StoredProcedure;
					
					rowsAffected = command.ExecuteNonQuery();
				}
				
				catch (Exception)
				{
					rowsAffected = -1;
					throw;
				}
				
				tran.Commit();
			}
		}
	}
