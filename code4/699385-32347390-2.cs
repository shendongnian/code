    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (!row.IsNewRow)
            {
                if (row.Cells[0].Value == null)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }
    }
