    string sql = "SELECT * FROM my query";
    SqlCommand cmd = new SqlCommand(sql, connection);
    using (SqlDataReader reader = cmd.ExecuteReader()) {
        while (reader.Read()) {
            for (int i = 0; i < reader.FieldCount; i++) {
                Console.WriteLine("{0} = {1}",
                                  reader.GetName(i),
                                  reader.IsDBNull(i) ? "NULL" : reader.GetValue(i));
            }
            Console.WriteLine("---------------");
        }
    }
