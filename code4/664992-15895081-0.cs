    DataView dv = table1.AsDataView();
    dv.RowFilter = fexpression; // for example "MyID = 3"
    DataTable table2 = dv.ToTable();
    
    // If you want typed datatable, you can do it like this (although there are other ways):
    MyTypedDataTable table2 = new MyTypedDataTable();
    DataTable tempTable = dv.ToTable();
    table2.Merge(tempTable);
