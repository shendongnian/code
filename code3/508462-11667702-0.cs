    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex == 1 && e.ColumnIndex == 2)
        {
            e.CellStyle.ForeColor = Color.Red;
        }
    }
