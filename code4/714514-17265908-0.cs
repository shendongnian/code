    using (var con = new SqlConnection(ConStr)) 
    {
        try 
        {
            con.Open();
            var adapter = new SqlDataAdapter();
            var cmd = new SqlCommand(dd.Value, con);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            ......
