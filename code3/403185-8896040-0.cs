    using(SqlCommand command = new SqlCommand("SELECT * FROM users WHERE Username =  @Username AND Password = @Password", connection))
    {
      command.Parameters.AddWithValue("@Username", username);
      command.Parameters.AddWithValue("@Password", password);
      using(SqlDataReader reader = command.ExecuteReader())
      {
        while(reader.Read())
        {
          //do actual works
        }
      }
    }
