    string connectionString = 
        @"Provider=Microsoft.Jet.OLEDB.4.0;" +
        @"Data Source=C:\path\to\your\database.mdb;" +
        @"User Id=;Password=;";
 
    string queryString = "SELECT Foo FROM Bar";
    
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    using (OleDbCommand command = new OleDbCommand(queryString, connection))
    {
        try
        {
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
    
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
  
