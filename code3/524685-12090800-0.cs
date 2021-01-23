    dataGridView.ColumnHeadersHeightSizeMode = 
        DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    
    foreach (DataGridViewColumn column in dataGridView.Columns)
    {
        column.HeaderCell.Style.WrapMode= DataGridViewTriState.True;
    }
