      string query = File.ReadAllText("yoursqlfilePath");
      using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlCommand command = new SqlCommand(query , connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
