    DataTable cbv = new DataTable();
    cbv.Columns.Add(new DataColumn("ColumnB"));
 
    // in a loop from a collection, presumably:
    cbv.Rows.Add(someThing.someValue);
     
    using (connectionObject)
    {
        SqlCommand cmd        = new SqlCommand("dbo.whatever", connectionObject);
        cmd.CommandType       = CommandType.StoredProcedure;
        SqlParameter cbvParam = cmd.Parameters.AddWithValue("@ColumnBValues", cbv);
        cbvParam.SqlDbType    = SqlDbType.Structured;
        //cmd.Execute...;
    }
