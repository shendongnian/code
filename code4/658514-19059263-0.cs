    string myConnectionString= @"DataSource =...";
    
    SqlConnection dbConnection = new SqlConnection(myConnectionString);
    
    string myCommand = "CREATE TABLE myTable (column1 VARCHAR(10),colunm2 INT)";
    
    SqlCommand dbConnection = new SqlCommand(myCommand,dbConnection);
    
    try
    {
    dbConnection.Open();
    
    dbCommand.ExecuteNonQuery();
    }
    
    catch{}
    
    dbConnection.Close();
