    public void Insert(string insertText)
    {
    
        string connectionString = Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI; User ID=myDomain\myUsername;Password=myPassword;
    
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
        connection.Open();
        connection.Open() SqlCommand command = new SqlCommand( "INSERT INTO Customers (CustomerID" + "VALUES (@ID)", connection);
    
        command.Parameters.Add("@ID", SqlDbType.NChar, 5, " + insertText+");
        command.ExecuteNonQuery();
        connection.Close();
        }
    }
