	using (SqlCommand cmd = new SqlCommand())
	{
		cmd.CommandText = "cus";
		cmd.CommandType = CommandType.StoredProcedure;
		//Configure input parameters
		SqlParameter param = new SqlParameter();
		param = cmd.Parameters.Add(new SqlParameter("@id", 2));
		param.Direction = ParameterDirection.Input;
		
		using (SqlConnection conn = new SqlConnection("Data Source=localhost; Integrated Security=SSPI; Initial Catalog=SpringApp;"))
		{
			conn.Open();
			cmd.Connection = conn;
			cmd.Prepare();
			
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
			
			}
		}
	}
