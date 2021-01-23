    paginationGirdView.Columns["colActualTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
    
    //assign value
    
    row.Cells["colActualTime"].Value = "yesterday";
    paginationGirdView.Columns["colActualTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
