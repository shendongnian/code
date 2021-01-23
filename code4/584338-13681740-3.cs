    private void dgvRptTables_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) {
            return;
        }
        int index = e.RowIndex;
        dgvGrid.Rows[index].Selected = true;
    }
