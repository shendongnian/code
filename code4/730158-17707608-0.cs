    using (SqlConnection c = new SqlConnection(connString))
    {
        c.Open();
        using (SqlDataAdapter sda = new SqlDataAdapter(
            "SELECT dbo.tbl_user.field1, dbo.tbl_user.field2 FROM tbl_user " +
            "WHERE dbo.tbl_user.name= @name", c))
        {
            sda.SelectCommand.Parameters.AddWithValue("@name", txt_search.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }
    }
