	int rowCount = 0;
	using (sql = conn.CreateCommand())
	{
	    sql.CommandText = query;
	    sql.Parameters.Add("@p_DateFrom", SqlDbType.VarChar).Value = datefrom.ToString("yyyy-MM-dd");
	    sql.CommandType = CommandType.Text;
	    rowCount = (Int32)sql.ExecuteScalar();
	}           
	return rowCount;
