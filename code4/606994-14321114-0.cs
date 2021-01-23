    public int MyMethod(string username, string password)
    {
      int count = 0;
      string query = "SELECT count(*) FROM accounts WHERE username = @user AND password = @pass LIMIT 1;";
       using (MySqlCommand cmd = new MySqlCommand(query, connector))
       {
          connector.Open(); 
          cmd.Parameters.AddWithValue("@user", username);
          cmd.Parameters.AddWithValue("@pass", password);       
          count = int.Parse(cmd.ExecuteScalar().ToString());
       }
       return count;
    }
