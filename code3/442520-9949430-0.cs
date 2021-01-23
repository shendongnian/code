    var dataTable1 = new DataTable();
    var dataTable2 = new DataTable();
    dataTable1.Columns.Add("keyCol", typeof(int));
    dataTable1.PrimaryKey = new[]{dataTable1.Columns[0]};
    dataTable1.Columns.Add("ValueCol");
    dataTable2.Columns.Add("keyCol", typeof(int));
    dataTable2.PrimaryKey = new[] { dataTable2.Columns[0] };
    dataTable2.Columns.Add("ValueCol");
    dataTable2.Columns.Add("ValueCol2");
