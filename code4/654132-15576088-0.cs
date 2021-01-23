    using (var con = new SqlConnection(constr))
    {
    
        using (var cmd = new SqlCommand(query))
        {
            using (var sda = new SqlDataAdapter())
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
