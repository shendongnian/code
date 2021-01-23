	private int GenerateReturnValue(int courseID, int studentID)
	{
		using (var connection = new SqlConnection("Your Connection String"))
		using (var command = new SqlCommand("assingCourse", connection)
		{
			connection.Open();
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@sID", System.Data.SqlDbType.VarChar).Value = studentID.ToString();
			command.Parameters.Add("@cID", System.Data.SqlDbType.VarChar).Value = courseID.ToString();
			command.Parameters.Add("@Return", System.Data.SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
			command.ExecuteNonQuery();
			
			return (int)command.Parameters["@Return"].Value;
		}
	}
	
