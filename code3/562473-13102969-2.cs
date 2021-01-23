    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 3)
            return;
        int nextRowIndex = e.RowIndex + 1;
        int lastRowIndex = dataGridView1.Rows.Count - 1;
        if (nextRowIndex <= lastRowIndex)
        {
            var value = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dataGridView1.Rows[nextRowIndex].Cells[2].Value = value;
        }
    }
