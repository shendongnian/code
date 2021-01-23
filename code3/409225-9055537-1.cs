    using(SqlConnection conn = new SqlConnection(connectionString))
    using(SqlCommand cmd = conn.CreateCommand())
    {
      conn.Open();
      cmd.CommandText = QueryLoader.ReadQueryFromFileWithBdateEdate(
        @"Resources\qrs\qryssysblo.q", newdate, newdate);
 
      using(SqlDataReader reader = cmd.ExecuteReader())
      using(StreamWriter writer = new StreamWriter("c:\temp\file.txt"))
      {
        while(reader.Read())
        {
          // Using Name and Phone as example columns.
          writer.WriteLine("Name: {0}, Phone : {1}", 
            reader["Name"], reader["Phone"]);
        }
      }
    }
