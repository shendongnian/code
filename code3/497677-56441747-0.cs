        //create a connection
        SqlConnection sqlConnection = new SqlConnection("Your Connection String");
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConnection;
        
        //open the connection
        sqlConnection.Open();
        
        //Your command query string
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT TOP 1 col_name FROM Customers";
        
        
        //Execute the reader
        SqlDataReader result  = cmd.ExecuteReader();
        result.Read();
        
        //close the connection
        sqlConnection.Close();
        
        return result["coiumn_name"].ToString(); 
