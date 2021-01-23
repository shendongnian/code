    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if ((dataGridView1.Columns[e.ColumnIndex] as DataGridViewButtonColumn) != null && dataGridView1.Rows[e.RowIndex].IsNewRow)
        {
            DataGridViewCellStyle emptyCellStyle = new DataGridViewCellStyle();
            emptyCellStyle.Padding = new Padding(75, 0, 0, 0);
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = emptyCellStyle;
        }
    }
