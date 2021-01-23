    string sql = "select listid from list where ShortDesc='Master'";
    SqlCeCommand cmdGetOldMasterId = new SqlCeCommand(sql, DbConnection.ceConnection);
    SqlCeDataAdapter da = new SqlCeDataAdapter(cmdGetOldMasterId);
    DataTable dt = new DataTable();
    da.Fill(dt);
    
    ....
    foreach(DataRow r in dt.Rows)
    {
        Console.WriteLine(r["listid"].ToString());
    }
