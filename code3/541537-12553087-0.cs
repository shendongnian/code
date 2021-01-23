    for (r = 0; r <= dataGridView1.RowCount - 1; r++)
    {
        for (c = 0; c <= dataGridView1.ColumnCount - 1; c++)
        {
            DataGridViewCell cell = dataGridView1[c, r];
            xlWorkSheet.Cells[r + 1, c + 1] = cell.Value;
        }
    }
