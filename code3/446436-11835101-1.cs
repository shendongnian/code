    public DataTable potentialFix(DataTable dt) {    
        DataTable newTable = new DataTable(dt.TableName);
        //define columns for the new table with type string (or whatever type you want)
        foreach (DataColumn dc in dt.Columns)
        {
            newTable.Columns.Add(new DataColumn(dc.ColumnName, typeof(String)));
        }
        newTable.BeginLoadData();
        DataTableReader dtReader = new DataTableReader(dt);
        newTable.Load(dtReader);
        newTable.EndLoadData();
        return newTable;
    }
