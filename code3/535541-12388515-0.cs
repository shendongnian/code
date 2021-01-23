    SqlConnection connection = new SqlConnection(...);
    connection.Open();
    SqlCommand command = new SqlCommand(...);
    command.Connection = connection;
    command.ExecuteNonQuery();
