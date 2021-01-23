    SqlConnection sqlConnection = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    Object returnValue;
    
    cmd.CommandText = "SELECT TOP 1 col_name FROM Customers";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection1;
    
    sqlConnection.Open();
    
    returnValue = cmd.ExecuteScalar();
    
    sqlConnection.Close();
    return returnValue.ToString(); //Note you have to cast it to your desired data type
