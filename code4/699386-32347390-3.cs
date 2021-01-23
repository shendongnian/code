    private int gridSelection = -1;
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (gridSelection != -1)
        {
            if (!dataGridView1.Rows[gridSelection].IsNewRow)
            {
                if (dataGridView1.Rows[gridSelection].Cells[0].Value == null)
                {
                    dataGridView1.Rows.RemoveAt(gridSelection);
                }
            }
        }
        gridSelection = dataGridView1.SelectedCells[0].RowIndex;
    }
