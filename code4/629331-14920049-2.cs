    public static DataTable Pivot(this DataTable tbl)
    { 
        var tblPivot = new DataTable();
        tblPivot.Columns.Add(tbl.Columns[0].ColumnName);
        for (int i = 1; i < tbl.Rows.Count; i++)
        {
            tblPivot.Columns.Add(Convert.ToString(i));
        }
        for (int col = 0; col < tbl.Columns.Count; col++)
        {
            var r = tblPivot.NewRow();
            r[0] = tbl.Columns[col].ToString();
            for (int j = 1; j < tbl.Rows.Count; j++)
                r[j] = tbl.Rows[j][col];
            tblPivot.Rows.Add(r);
        }
        return tblPivot;
    }
