    private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 1)
            {
                if ((int)e.Value == 3)
                    e.CellStyle.BackColor = Color.Blue;
                if ((int)e.Value == 2)
                    e.CellStyle.BackColor = Color.Red;
            }
    }
