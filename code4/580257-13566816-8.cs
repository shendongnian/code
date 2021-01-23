    public void Insert(string customerName)
    {
    try
       {
        string connectionString = Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI; User ID=myDomain\myUsername;Password=myPassword;
    
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
        connection.Open();
        connection.Open() SqlCommand command = new SqlCommand( "INSERT INTO Customers (CustomerName" + "VALUES (@Name)", connection);
    
        command.Parameters.Add("@Name", SqlDbType.NChar, 50, " + customerName +");
        command.ExecuteNonQuery();
        connection.Close();
        }
     catch()
     {
         //Logic in here
     }
     finally()
     {
        if(con.State == ConnectionState.Open)
        {
            connection.Close();
        }
     }
  }
