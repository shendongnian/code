    private void DataGridView1_CellFormatting(object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        DataGridView dgv = (DataGridView)sender;
        if (dgv.Columns[e.ColumnIndex].Name == "TargetColumnName" &&
            e.RowIndex >= 0 &&
            dgv["TargetColumnName", e.RowIndex].Value is int)
        {
            switch ((int)dgv["TargetColumnName", e.RowIndex].Value)
            {
                case 1:
                    e.Value = "one";
                    e.FormattingApplied = true;
                    break;
                case 2:
                    e.Value = "two";
                    e.FormattingApplied = true;
                    break;
            }
        }
    }
