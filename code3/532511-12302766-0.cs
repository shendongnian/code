    DataTable dt = new System.Data.DataTable();
    dt.Columns.Add("FKStuff");
    dt.Columns.Add("OtherStuff");
    dt.Columns.Add("FKAndMoreStuff");
    
    var row = dt.Rows.Add("ABC", "DEF", "GHI");
    var vals = dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FK")).Select(col => row[col]).ToArray();
