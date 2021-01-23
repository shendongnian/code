    foreach(var table in DataSet1.Tables) {
        foreach(var col in table.Columns) {
           ...
        }
        foreach(var row in table.Rows) {
            object[] values = row.ItemArray;
            ...
        }
    }
