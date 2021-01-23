    using (SqlConnection con = new SqlConnection("SomeConnectionString"))
    {
      var cmd = new SqlCommand("select from myTable where myPK==N'"+ simpleText+ "'",con);
      cmd.Connection.Open();
      var sqlReader = cmd.ExecuteReader();
      while(sqlReader.Read())
      {
        //Fill some data like : string result = sqlReader("SomeFieldName");
      }
      sqlReader.Close();
      cmd.Connection.Close();
      cmd.Dispose();
    }
