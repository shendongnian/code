    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 1)
        {
            if (string.IsNullOrEmpty(dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString()))
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() == "Yes")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                }
            }
            else
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
        }
    }
