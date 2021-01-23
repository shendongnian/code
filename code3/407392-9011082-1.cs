    DataTable table = new DataTable(); // This would be your existing DataTable
    // Grab only the rows that meet your criteria using the .Select() method
    DataRow[] newRows = table.Select("ClientID LIKE '%A-%' AND ClientID LIKE '%N6%'");
    // Create a new table with the same schema as your existing one.
    DataTable newTable = table.Clone();
    foreach (DataRow r in newRows)
    {
        // Dump the selected rows into the table.
        newTable.LoadDataRow(r.ItemArray, true);
    }
