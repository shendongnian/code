    // your query
    var timesheets = ...
    
    // design table first
    DataTable table = new DataTable();
    table.Columns.Add(new DataColumn
        {
            ColumnName = "TaskName",
            DataType = typeof(String);
        });
    ...
    
    List<DataRow> list = new List<DataRow>();
    foreach (var t in timesheet)
    {
        var row = table.NewRow();
        row.SetField<string>("TaskName", t.taskName); // extension method from System.Data.DataSetExtensions.dll
        ...
        list.Add(row);
    }
    
    DataTable table = list.CopyToDataTable(); // extension method too
