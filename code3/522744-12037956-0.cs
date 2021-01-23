    using (SqlCommand cmd1 = new SqlCommand("INSERT INTO Userinformation(Access) VALUES(@NameAccess) WHERE User_ID=@UserId, con))
    {
        cmd1.Parameters.AddWithValue("@NameAccess", nameAccess.Text);
        cmd1.Parameters.AddWithValue("@UserId", userIdaccess.Text);
        using (SqlDataReader dr = cmd1.ExecuteReader())
        {
            if (dr.Read())
            {
                MessageBox.Show("User Access Blocked");
            }
        }
    }
