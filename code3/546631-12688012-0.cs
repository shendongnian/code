    public void Insert(String query)
     {
            using(var connection = new MySqlConnection("..."))
            {
                connection.Open();
                using(var  cmd = new MySqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
      }
