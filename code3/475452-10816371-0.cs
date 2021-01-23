		private void FillDetailsFromDb(Guid p)
		{
			SqlCommand com = new SqlCommand();
			com.Connection = conn;
			com.CommandText = "spSelectProspectUsingLinkParameter";
			com.CommandType = CommandType.StoredProcedure;
			com.Parameters.AddWithValue("@linkparam", p);
			conn.Open();
			SqlDataReader rdr = com.ExecuteReader();
            ...
            etc
        }
