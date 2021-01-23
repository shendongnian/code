    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
        if (e.RowIndex < 1 || e.ColumnIndex < 0)
            return;
        if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
        {
            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        }
        else
        {
            e.AdvancedBorderStyle.Top = dataGridView1.AdvancedCellBorderStyle.Top;
        }  
    }
