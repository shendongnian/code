    private void dgvRptTables_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) {
            return;
        }
        intIndex = e.RowIndex;
        dgvGrid.Rows(intIndex).Selected = true;
    }
