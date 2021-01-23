    private DataRow JoinDataRow(DataRow r1, DataRow r2)
    {
        // Get table columns
        var r1Cols = r1.Table.Columns;
        var r2Cols = r2.Table.Columns;
        // Create datatable to base row from
        var tempDataTable = new DataTable();
        foreach (DataColumn col in r1Cols)
        {
            tempDataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType, col.Expression, col.ColumnMapping));
        }
        foreach (DataColumn col in r2Cols)
        {
            tempDataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType, col.Expression, col.ColumnMapping));
        }
        // Create new return row to be returned
        DataRow returnRow = tempDataTable.NewRow();
        // Fill data
        int count = 0;
        for (int r1Index = 0; r1Index < r1Cols.Count; r1Index ++)
        {
            returnRow[r1Index] = r1[r1Index];
            count++;
        }
        for (int r2Index = count; r2Index < r2Cols.Count + count; r2Index++)
        {
            returnRow[r2Index] = r2[r2Index -count];
        }
        // Return row
        return returnRow;
    }
