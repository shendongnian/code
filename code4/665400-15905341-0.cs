	//requires query parameters to have names @0, @1 etc in string
	public static List<object[]> Query(String query, params String[] parameters) //no injection check on this string, be careful.
	{
		using(SqlConnection conn = new SqlConnection(_CONN_STRING_))
		{
			conn.Open()
			using(SqlCommand cmd = new SqlCommand(query, conn))
			{
				AddSqlParams(cmd, parameters);
				return Query(cmd);
			}
			
		}
	}
	
	/// <summary>Generic SQL query. Requires open connection.</summary>
	/// <param name="cmd">SqlCommand object with all necessary fields configured.</param>
	/// <returns>A list of Object arrays (each array is one row).</returns>
	private static List<Object[]> Query(SqlCommand cmd)
	{
		List<Object[]> results = new List<Object[]>();
		using (SqlDataReader rdr = cmd.ExecuteReader())
		{
			while (rdr.Read())
			{
				Object[] row = new Object[rdr.VisibleFieldCount];
				rdr.GetValues(row);
				results.Add(row);
			}
			return results;
		}
	}
	
	private static void AddSqlParams(SqlCommand cmd, params String[] sqlParams)
	{
		for (Int32 i = 0; i < sqlParams.Length; i++)
			cmd.Parameters.AddWithValue("@" + i, (Object)sqlParams[i] ?? DBNull.Value);
	}
