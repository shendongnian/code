    SqlCommand command = new SqlCommand(queryString, connection);
    IList<int> ints = new List<int>();
    using(SqlDataReader reader = command.ExecuteReader()) {
         while (reader.Read())
         {
             ints.add(reader.GetInt32(0)); // provided that first (0-index) column is int which you are looking for
         }
    }
