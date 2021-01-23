      string[] query = File.ReadAllLines("yoursqlfilePath");
      StringBuilder sb = new StringBuilder();
      foreach(string s in query)
      {
         sb.Append(s);
       }
      using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlCommand command = new SqlCommand(s.ToString(), connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
