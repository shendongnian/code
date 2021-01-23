    myTable = new DataTable();
    DataColumn values = new DataColumn("Test");
    myTable.Columns.Add(values);
    DataRow rd = myTable.NewRow();
    rd["Test"] ="";
    myTable.Rows.Add(rd);
    datagridview1.DataSource = myTable;
