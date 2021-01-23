    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (!dataGridView1.Rows[e.ColumnIndex].IsNewRow && e.ColumnIndex == dataGridView1.Columns["InterestingColumn"].Index)
        {
            if (e.Value == null)
                return;
            if (e.Value.ToString() == "TargetValue")
            {
                e.Value = "DisplayValue";
            }
        }
    }
