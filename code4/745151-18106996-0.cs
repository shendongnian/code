    DataTable table = ds.Tables[0];
    DataTable clonedTable = table.Clone();
    clonedTable.Columns["EmployeeID"].DataType = typeof(String);
    foreach (DataRow row in table.Rows)
    {
        clonedTable.ImportRow(row);
    }
    foreach (DataRow row in clonedTable.Rows)
    {
        row["EmployeeID"] = "*" + row["EmployeeID"].ToString();
    }
    return clonedTable;
