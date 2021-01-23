    AddTof1(string s) 
    {    
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
          connection.Open();
    
          using (SqlCommand command = new SqlCommand("INSERT INTO table1 values(@s)", connection))
          {
              command.Parameters.AddWithValue("@s", s);
              command.ExecuteNonQuery();
          }
      }
    
    }
