    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand(query))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                sda.Fill(dt);
            }
        }
        return dt;
    }
