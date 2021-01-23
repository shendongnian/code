    DataTable table = new DataTable(); // This would be your existing DataTable
    // Grab only the rows that meet your criteria using the .Select() method
    DataRow[] newRows = table.Select("ClientID LIKE '%A-%' AND ClientID LIKE '%N6%'");
    // Clear out the old table
    table.Clear();
    foreach (DataRow r in newRows)
    {
        // Dump the selected rows into the table.
        table.LoadDataRow(r.ItemArray, true);
    }
