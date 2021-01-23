    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        int idx = e.RowIndex;
        DataGridViewRow row = dataGridView1.Rows[idx];
        long newNo = idx;
        if (!_RowNumberStartFromZero)
            newNo += 1;
        long oldNo = -1;
        if (row.HeaderCell.Value != null)
        {
            if (IsNumeric(row.HeaderCell.Value))
            {
                oldNo = System.Convert.ToInt64(row.HeaderCell.Value);
            }
        }
        if (newNo != oldNo)
        {
            row.HeaderCell.Value = newNo.ToString();
            row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
