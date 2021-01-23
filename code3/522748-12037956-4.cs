    using (SqlCommand cmd1 = new SqlCommand("INSERT INTO Userinformation(Access) VALUES(@NameAccess)", con))
    {
        cmd1.Parameters.AddWithValue("@NameAccess", nameAccess.Text);
        using (SqlDataReader dr = cmd1.ExecuteReader())
        {
            if (dr.Read())
            {
                MessageBox.Show("User Access Blocked");
            }
        }
    }
