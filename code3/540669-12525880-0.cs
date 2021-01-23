    private void SetDGVButtonColumnEnable(bool enabled) {
        foreach (DataGridViewRow row in dataGridView1.Rows) {
            // Set Enabled property of the forth column in the DGV.
            ((DataGridViewDisableButtonCell)row.Cells[3]).Enabled = enabled;
        }
        dataGridView1.Refresh();
    }
