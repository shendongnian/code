    using (var con = new SqlConnection("...connection string here..."))
    {
        var com = con.CreateCommand();
        com.CommandText = "GetTablesData"; 
        com.CommandType = CommandType.StoredProcedure;
        con.Open():
        using (var read = cmd.ExecuteReader())
        {
            if (!read.Read())
                throw new Exception("No rows returned!")l
            
            if (read["Column1"] as int < 7)
            {
                var col2 = read["Column2"] as string;
                // Do stuff with col2
            }
        }
    }
