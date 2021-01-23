    public int MyMethod(string username, string password)
    {
        int count = 0;
        string query = "SELECT * FROM accounts WHERE username = @user AND password = @pass LIMIT 1;";
    
        using (MySqlCommand cmd = new MySqlCommand(query, connector))
        {
            cmd.Parameters.Add(new MySqlParameter("@user", username));
            cmd.Parameters.Add(new MySqlParameter("@pass ", password));
    
            connector.Open(); // don't forget to open the connection
            count = int.Parse(cmd.ExecuteScalar().ToString());
        }
    
        return count;
    }
