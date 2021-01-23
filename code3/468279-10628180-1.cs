    using (MySqlConnection cn = GetConnection())
    {
        cn.Open();
        // create the command and link it to the connection
        using (var cmd = new MySqlCommand("Select salt From niki where user_name = @username", cn)) 
        { 
            cmd.Parameters.AddWithValue("@username", username); 
            salt = cmd.ExecuteScalar() as string; 
        }
    } 
    public MySqlConnection GetConnection()
    {
         MySqlConnection cn = new MySqlConnection("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;");
         return cn;
    }
