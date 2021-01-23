	private void UpdateProblem(string problemName, string problemDescription, int problemId, object[] fieldValues)
	{
		SqlConnection 	con = null;
		SqlCommand 		cmd = new SqlCommand();
		StringBuilder   sql = new StringBuilder();
		int				fieldCounter = 1;
		
		// start building the sql statement
		sql.AppendFormat("UPDATE {0} SET ProbDesc = @ProbDesc", problemName);
		
		// add the 'description' parameter
		cmd.Parameters.Add(new SqlParameter("@ProbDesc", problemDescription));
		
		// add each field value to the update statement... the SqlParameter will infer the database type.
		foreach(object fieldValue in fieldValues)
		{
			// add additional SET clauses to the statement
			sql.AppendFormat(",field{0} = @field{0}", fieldCounter);
			
			// add the field parameter to the command's collection
			cmd.Parameters.Add(new SqlParameter(String.Format("@field{0}", fieldCounter), fieldValue));
			
			fieldCounter++;
		}
		// finish up the SQL statement by adding the where clause
		sql.Append(" WHERE (ProbId = @ProbId)");
		
		// add the 'problem ID' parameter to the command's collection
		cmd.Parameters.Add(new SqlParameter("@ProbId", problemId));
		
		// finally, execute the SQL
		try
		{
			con.Open();
			
			cmd.Connection = con;
			
			cmd.CommandText = sql.ToString();
						
			cmd.ExecuteNonQuery();
		}
		catch(SqlException ex)
		{
			// do some exception handling
		}
		finally
		{
			if(con != null)
				con.Dispose();
		}
	}
