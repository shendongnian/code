    myTable = new DataTable();
    DataColumn values = new DataColumn("Id");
    myTable.Columns.Add(values);
    DataRow rd = myTable.NewRow();
    rd["Id"] ="";
    myTable.Rows.Add(rd);
    datagridview1.DataSource = myTable;
