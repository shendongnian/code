    MySQLCommand cmd = new MySQLCommand("SELECT Price FROM Products", connection);
    MySQLDataReader reader = cmd.ExecuteReaderEx();
    
    if (reader.HasRows)
    {
      while (reader.Read())
      {
        price = double.Parse(reader["Price"]).ToString());
      }
    }
