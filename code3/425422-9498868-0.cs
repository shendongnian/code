    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	connection.Open();
    
    	SqlCommand sqlCommand = 
            new SqlCommand("SELECT * FROM dbo.Tbldelivery WHERE refno=@refno", 
                            connection);
    
    	sqlCommand.Parameters.Add("@refno", System.Data.SqlDbType.VarChar);
    	sqlCommand.Parameters["@refno"].Value = refnoValue;
    
    	SqlDataReader reader = sqlCommand.ExecuteReader();
    	reader.Read();
    	if (reader.HasRows)
    	{
    	// refno exists
    	}
    	else
    	{
    	// refno does not exist
    	}
    }
