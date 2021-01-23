    public int UpdateUserInfo(
        string oldusername, 
        string newusername, 
        string mailid, 
        string password
    )
    {
        using (var con = new MySqlConnection(conString))
        using (var cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = "SELECT count(UserName) from tbl_UserInfo where UserName = @newusername";
            cmd.Parameters.AddWithValue("@newusername", newusername);
            var count = (long)cmd.ExecuteScalar();
            if (count < 1)
            {
                return 0;
            }
        }
        using (var con = new MySqlConnection(conString))
        using (var cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = "UPDATE tbl_UserInfo SET UserName = @newusername, Password = @password, Email_ID = @mailid WHERE UserName = @oldusername";
            cmd.Parameters.AddWithValue("@newusername", newusername);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@mailid", mailid);
            cmd.Parameters.AddWithValue("@oldusername", oldusername);
            return cmd.ExecuteNonQuery();
        }
    }
