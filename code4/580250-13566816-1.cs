        string connectionString = Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI; User ID=myDomain\myUsername;Password=myPassword;
        string queryString = "INSERT INTO table_name (column1) VALUES (" + wordToInsert + ")"; //update as you feel fit of course for insert/update etc
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open()
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand(queryString, connection);        
        command.ExecuteNonQuery();
        connection.Close();
    }
