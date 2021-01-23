    public void UpdateGridView()
    {
        HashSet<string> selectedRows = new HashSet<string>();
        foreach (DataGridViewRow row in grid.Rows)
        {
            if (row.Selected)
                selectedRows.Add(row.Cells[ColCookieID].Value.ToString());
        }
        var currentRow = grid.CurrentRow.Cells[ColCookieID].Value.ToString()
        
        // ... update the grid
        
        foreach (DataGridViewRow row in grid.Rows)
        {
            var id = row.Cells[ColCookieID].Value.ToString();
            if (selectedRows.Contains(id))
                row.Selected = true;
            if (currentRow == id)
                grid.CurrentCell = row.Cells[0];
        }
    }
