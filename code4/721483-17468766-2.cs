    protected void RetriveProfile()
    {
        conn = new SqlConnection(connString);
        cmdProfile = new SqlCommand("SELECT Name, UserId FROM UserProfile WHERE UserName=@UserName",conn);
        cmdProfile.Parameters.AddWithValue("@UserName",userName);
        conn.Open();
        reader = cmdProfile.ExecuteReader();
        while (reader.Read())
        {
            TextBoxName.Text = reader["Name"].ToString();
            UserId = reader["UserId"].ToString();
        }
        conn.Close();
    }
