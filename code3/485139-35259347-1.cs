    private bool Login(string username, string password)
    {
        try
        {
            MySqlCommand cmd = MySqlConn.cmd;
            cmd = new MySqlCommand(
                "SELECT count(*) FROM admin " + 
                "WHERE admin_username=@username " + 
                "AND admin_password=PASSWORD(@passwd)",
                MySqlConn.conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@passwd", password);
            int result = (int)cmd.ExecuteReader();
            // Returns true when username and password match:
            return (result > 0);
        }
        catch (Exception e)
        {
            // Optional: log exception details
                
            // Deny log in if an error has occurred:
            return false;
        }
    }
