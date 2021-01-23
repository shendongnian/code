    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1.RowCount > 0 && e.RowIndex == dataGridView1.RowCount - 1)
        {
            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
            {
                if (cell.Value == null)
                {
                    return;
                }
            }
            dataGridView1.Rows.Add();
        }
    }
