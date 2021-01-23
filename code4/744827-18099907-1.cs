    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT userid,username,email,city FROM USERS where username=@username and password=@password", con);
        cmd.Paramters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        cmd.CommandType = CommandType.Text;
        UserInfo info = new UserInfo();
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
            if (rdr.HasRows)
            {
                rdr.Read(); // get the first row
                info.UserID = rdr.GetInt32(0);
                info.UserName = rdr.GetString(1);
                info.Email = rdr.GetString(2);
                info.City = rdr.GetString(3);
            }
        }
    }
