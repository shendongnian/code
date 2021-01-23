    // Create total column.
    DataColumn totalColumn = new DataColumn();
    totalColumn.DataType = System.Type.GetType("System.Decimal");
    totalColumn.ColumnName = "total";
    totalColumn.Expression = "AmountSold + AmountUpgraded";
    // Add columns to DataTable.
    ...
    table.Columns.Add(totalColumn);
