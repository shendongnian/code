    private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        DataGridView grid = (DataGridView)sender;
        if (grid[e.ColumnIndex, e.RowIndex].ReadOnly)
        {
            e.Value = string.Empty;
            e.FormattingApplied = true;
        }
    }
