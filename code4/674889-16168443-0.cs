    using(var reader = command.ExecuteReader())
    {
        reader.Read();
        var table = reader.GetSchemaTable();
        foreach (DataColumn column in table.Columns)
        {
            Console.WriteLine(column.ColumnName);
        }
     }
