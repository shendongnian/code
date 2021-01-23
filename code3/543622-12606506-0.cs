    public static void PostProcessData(ref DataTable dataTable)
    {
        // Convert byte[] columns.
        List<DataColumn> colCollRem = new List<DataColumn>();
        List<DataColumn> colCollAdd = new List<DataColumn>();
        foreach(DataColumn col in dataTable.Columns)
            if (col.DataType == typeof(byte[]))
                colCollRem.Add(col);
        // Remove old add new.
        foreach (DataColumn col in colCollRem)
        {
            int tmpOrd = col.Ordinal;
            string colName = String.Format("{0}(Hex)", col.ColumnName);
            DataColumn tmpCol = new DataColumn(colName, typeof(String));
            dataTable.Columns.Add(tmpCol);
            colCollAdd.Add(tmpCol);
            foreach (DataRow row in dataTable.Rows)
                row[tmpCol] = Utilities.ByteArrayToHexString((byte[])row[col]);
            dataTable.Columns.Remove(col);
            string colNameNew = colName.Replace("(Hex)", String.Empty);
            dataTable.Columns[colName].ColumnName = colNameNew;
            dataTable.Columns[colNameNew].SetOrdinal(tmpOrd);
        }
    }
