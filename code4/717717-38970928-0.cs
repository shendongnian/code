    DataTable table = new DataTable();
    foreach (DataColumn column in table .Columns)
    {
        Console.Write("Item: ");
        Console.Write(column.ColumnName);
        Console.Write(" ");
        Console.WriteLine(row[column]);
    }
