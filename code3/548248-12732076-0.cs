    string commandText = "SELECT * FROM Sales WHERE CustomerID = @ID;";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@ID", SqlDbType.Int);
        command.Parameters["@ID"].Value = customerID;
        var reader = command.ExecuteReader();
        //.....
    }
