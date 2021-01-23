    using (SqlCeConnection con = new SqlCeConnection(connectionString))   
    {   
        con.Open();   
        SqlCeCommand cmd = new SqlCeCommand("Select * from MyTable1 Where 1=0", con);
        SqlCeDataAdapter da = new SqlCeDataAdapter();
        da.SelectCommand = cmd;
        SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
        da.Update(table1);
    }
