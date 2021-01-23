    private DataSet BuildDataGridColumns()
    {
        // Build the data.
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Tables.Add(dt);
        // Add the columns to the DataTable.
        DataColumn indexCol = new DataColumn("Key Index", typeof(String));
        dt.Columns.Add(indexCol);
        DataColumn fileCol = new DataColumn("File Name", typeof(String));
        dt.Columns.Add(fileCol);
        DataColumn resCol = new DataColumn("Resource Name", typeof(String));
        dt.Columns.Add(resCol);
        return ds;
    }
