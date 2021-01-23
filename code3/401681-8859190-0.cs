     SqlConnection someConnection = new SqlConnection(connection);
     SqlCommand someCommand = new SqlCommand();
     someCommand.Connection = someConnection;
     someCommand.Parameters.Add(
        "@username", SqlDbType.NChar).Value = name;
     someCommand.Parameters.Add(
        "@password", SqlDbType.NChar).Value = password;
     someCommand.CommandText = "SELECT AccountNumber FROM Users " + 
        "WHERE Username=@username AND Password=@password";
     someConnection.Open();
     object accountNumber = someCommand.ExecuteScalar();
     someConnection.Close();
