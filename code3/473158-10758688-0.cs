    public static SqlCommand CreateCommand(List<int> ints)
    {
        var dt = new DataTable();
        dt.Columns.Add("ID",typeof(Int32));
        for (int i = 0; i < ints.Count; i++)
    	{
            dt.Rows.Add(ints[i]);
    	}
    
        SqlCommand cmd = new SqlCommand("SomeStoredProc");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 120;
        var param1 = cmd.Parameters.AddWithValue("@SomeParam", dt);
        param1.SqlDbType = SqlDbType.Structured;
        param1.TypeName = "dbo.tableOf_Ints";
                        
        return cmd;
    }
