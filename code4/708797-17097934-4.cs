    string procName = "listtest";
    string cs = "Data Source=server;Initial Catalog=dbname;User ID=user;Password=password;Trusted_Connection=False;";
    SqlConnection conn=new SqlConnection(cs);
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = new SqlCommand(procName, conn);
    da.SelectCommand.CommandType = CommandType.StoredProcedure;
    DataSet ds = new DataSet();
    da.Fill(ds);
    ds.Tables["Table"].TableName = "Rows";
    List<mList> newlist = ds.Tables["Rows"].AsEnumerable().Select(row => new mList
    {
        Ee = row.Field<DateTime?>(0).GetValueOrDefault(),
        ndate = row.Field<DateTime?>(1).GetValueOrDefault(),
        SNo = row.Field<int?>(2).GetValueOrDefault(),
        CId = row.Field<int?>(3).GetValueOrDefault(),
        rID = row.Field<int?>(4).GetValueOrDefault()
    }).ToList();
