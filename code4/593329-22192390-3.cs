    public void instantiateDataTable(DataTable dt)
    {
        dt.Columns.Add(New DataColumn("S.No",typeof(int)));
        dt.Columns.Add(New DataColumn("Name",typeof(string)));
    }
