    string query = @"SELECT Count(*) FROM [CompaniesDB].[dbo].[Companies] WHERE BolagsID = @BolagsID";
	using (SqlCommand cmd = new SqlCommand(query, conn))
	{
	    cmd.Parameters.Add("@BolagsID", SqlDbType.NVarChar).Value = BolagsID;
	    conn.Open();
	    MessageBox.Show("TEST: {0}", Convert.ToString((int)cmd.ExecuteScalar()));
	    conn.Close();
	}
