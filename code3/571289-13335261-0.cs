    using (SqlConnection c = new SqlConnection("FOO"))
    {
        c.Open();
        String sql = @"
            SELECT Salt, Password 
            FROM Users 
            WHERE (Email = @Email)";
        using (SqlCommand cmd = new SqlCommand(sql, c))
        {
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = _Email;
            using (SqlDataReader d = cmd.ExecuteReader())
            {
                if (d.Read())
                {
                    byte[] salt = (byte[])d["Salt"];
                    byte[] pass = (byte[])d["Password"];
                                
                    //Do stuff with salt and pass
                }
                else
                {
                    // NO User with email exists
                }
            }
        }
    }
