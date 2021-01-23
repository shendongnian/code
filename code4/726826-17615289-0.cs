    SqlCommand command = new SqlCommand(queryString, connection);
    SqlDataReader reader = command.ExecuteReader();
    if (reader.Read())
    {
        Console.WriteLine(String.Format("{0}", reader[0]));
    }
