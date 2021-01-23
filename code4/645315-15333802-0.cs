    using (SqlConnection connection = new SqlConnection(strCon)) 
    {
        SqlCommand command = new SqlCommand(sSQL, connection);
        connection.Open();
        command.ExecuteNonQuery();
    }
