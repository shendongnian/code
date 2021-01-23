    using (var = new SqlConnection(_connectionstring))
    {
        try
        {
            connection.Open();
            
			using(SqlTransaction transaction = connection.BeginTransaction())
            {
			    using (SqlCommand command1= new SqlCommand(commandtext, connection, transaction ))
                {
                    //Do something here
                }
                using (SqlCommand command2= new SqlCommand(commandtext, connection, transaction ))
                {
                    //Do another stuff here
                }
				...
                transaction .Commit();	
			}
        }
        catch (Exception Ex)
        {
            if (transaction != null) transaction .Rollback();
        }
    }
