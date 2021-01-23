    DataTable dt = new DataTable();
    using (SqlConnection c = new SqlConnection(cString))
    {
        using (SqlDataAdapter sda = new SqlDataAdapter(sql, c))
        {
            sda.SelectCommand.Parameters.Add("parm1", value1);
            c.Open();
            sda.Fill(dt);
        }
    }
