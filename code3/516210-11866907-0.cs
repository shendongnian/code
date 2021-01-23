    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == myColumnIndex && e.RowIndex >= 0)
        {
            if (e.Value is double)
            {
                // this will show "x" if value is 0, and "-" if value is 1
                double v = (double)e.Value; 
                if (v == 0)
                {
                    e.Value = "x";
                    e.FormattingApplied = true;
                }
                else if (v == 1)
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }
        }
    }
