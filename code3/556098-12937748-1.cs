    var table = new DataTable();
    table.Columns.Add("Colum1", typeof(string));
    table.Columns.Add("Colum2", typeof(int));
    table.Columns.Add("Colum3", typeof(string));
    Random r = new Random();
    for (int i = 0; i < 100; i++)
    {
        table.Rows.Add("Colum1_" + r.Next(1, 10), r.Next(1, 10), "Colum3_" + r.Next(1, 10));
    }
    var newOrderedTable = ReorderTable(table, "Colum3", "Colum2", "Colum1");
