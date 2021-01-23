    foreach (DataGridViewColumn col in dataGridView2.Columns){
        col.SortMode = DataGridViewColumnSortMode.NotSortable; // This first set it work
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }
