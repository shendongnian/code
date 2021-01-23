    string sql = @"INSERT INTO UserInfo (UserName) VALUES (@UserName)";
    using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
    using(var cmd = new SqlCommand(sql, con))
    {
        con.Open();
        foreach(var user in result.Where(x => x.UserName.Contains('@')))
        {
            // you don't need to set the UserID when you've set made it an Identity column
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.ExecuteNonQuery();
        }
    }
