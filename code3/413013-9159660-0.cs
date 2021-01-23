    public DataTable GetInitData()
    {
        var empDS = new DataSet();
        var empTbl = new DataTable();
        empDS.Tables.Add(empTbl);
        var dc = new DataColumn("Test");
        empDS.Tables[0].Columns.Add(dc);
        var row = empDS.Tables[0].NewRow();
        //row[0] = "foo";
        empDS.Tables[0].Rows.Add(row);
        empDS.AcceptChanges();
        return empDS.Tables[0];
    }
