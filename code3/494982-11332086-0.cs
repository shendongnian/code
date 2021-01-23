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
        for (int i = 0; i < ele; i++)
        {
            row[i] = datar[i, j];
        }
         _myDataTable.Rows.Add(row);
    }
