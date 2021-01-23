	int fNameId = -1, lNameId = -1;
	SqlConnection sqlConn = new SqlConnection(conString);//conString is the connection string for your DB.  This should be the same as what you use to execute the stored procedure.
	SqlCommand sqlQuery = new SqlCommand("SELECT AttributeID, AttributeName FROM Attribute WHERE AttributeName IN ('FirstName','LastName')", sqlConn);
	SqlDataReader sqlReader;
	sqlConn.Open();
	sqlReader = sqlQuery.ExecuteReader();
	if (sqlReader.HasRows)
	{
		while (sqlReader.Read())
		{
			if (sqlReader[1].ToString().Equals("FirstName", StringComparison.CurrentCultureIgnoreCase))
			{
				fNameId = (int)fNameId;
			}
			else if (sqlReader[1].ToString().Equals("LastName", StringComparison.CurrentCultureIgnoreCase))
			{
				lNameId = (int)fNameId;
			}
		}
	}
	sqlReader.Close();
	sqlConn.Close();
