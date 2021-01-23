        GridViewRow row = e.Row;
        // Intitialize TableCell list
        List<TableCell> columns = new List<TableCell>();
        foreach (DataControlField column in GridView1.Columns)
        {
            if (row.Cells.Count > 0)
            {
            //Get the first Cell /Column
            TableCell cell = row.Cells[0];
            // Then Remove it after
            row.Cells.Remove(cell);
            //And Add it to the List Collections
            columns.Add(cell);
            }
        }
        // Add cells
        row.Cells.AddRange(columns.ToArray());
}
