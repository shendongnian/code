    public DataSet SelectDs(string str)
    {
        DataSet ds = new DataSet();
    
        using(SqlConnection con = new SqlConnection(constring))  // CREATE
        using(SqlCommand cmd = new SqlCommand(str, con))         // CREATE
        {
            con.Open();    // OPEN
            cmd.CommandTimeout = 12000;
            using(SqlAdapter adpt = new SqlAdapter(cmd))   // USE
                 adpt.Fill(ds);
    
            return ds;
        }  // CLOSE & DESTROY 
    }
