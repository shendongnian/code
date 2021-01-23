    DataGridViewCellStyle style = new DataGridViewCellStyle();
    style.Alignment.WrapMode = DataGridViewTriState.True;
    foreach (DataGridViewColumn column in dataGridView.Columns)
    {
        column.HeaderCell.Style = style;
    }
