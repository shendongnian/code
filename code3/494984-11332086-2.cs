    DataTable _myDataTable = new DataTable();
    // create columns
    for (int i = 0; i < ele; i++)
    {
        _myDataTable.Columns.Add();
    }
    for (int j = 0; j < caract; j++)
    {
        // create a DataRow using .NewRow()
        DataRow row = _myDataTable.NewRow();
        // iterate over all columns to fill the row
        for (int i = 0; i < ele; i++)
        {
            row[i] = datar[i, j];
        }
        // add the current row to the DataTable
        _myDataTable.Rows.Add(row);
    }
