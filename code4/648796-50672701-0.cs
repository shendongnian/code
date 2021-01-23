    private void dtg_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                dtg.ReadOnly = false;
            }
    }
