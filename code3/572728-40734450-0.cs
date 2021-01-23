        List<DataGridViewRow> toBeDeleted = new List<DataGridViewRow>();
        try
        {
            foreach (DataGridViewRow row in DataGrid.SelectedRows)
                toBeDeleted.Add(row);
            foreach (DataGridViewRow row in toBeDeleted)
                DataGrid.Rows.Remove(row);
        }
        catch (Exception) { }
