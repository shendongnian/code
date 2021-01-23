    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "Track")
        {
            uint value = (uint)e.Value;
            if (value == 0)
            {
                e.Value = string.Empty;
                e.FormattingApplied = true;
            }
        }
    }
