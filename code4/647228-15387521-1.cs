    string strSQLconnection = (connectionString);
    SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
    sqlConnection.Open();
    SqlCommand sqlCommand = new SqlCommand("p1", sqlConnection);
    sqlCommand.CommandType = CommandType.StoredProcedure;
    sqlCommand.Parameters.AddWithValue("@tabName", "table1");
    sqlCommand.Parameters.AddWithValue("@colName", "col1");
    sqlCommand.Parameters.AddWithValue("@colVal", "1");        
        
    SqlDataReader reader = sqlCommand.ExecuteReader();
    sqlConnection.Close();
