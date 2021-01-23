    void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if(gridView.CurrentCell.GetType() != typeof(DataGridViewCheckBoxCell))
        return;
      if(!gridView.CurrentCell.IsInEditMode)
        return;
      if(!gridView.IsCurrentCellDirty)
        return;
      gridView.EndEdit();
    }
        
    void gridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
      if(e.ColumnIndex == gridView.Columns["cFlag"].Index && e.RowIndex >= 0)
        gridView.EndEdit();
    }
        
    void gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      if(e.ColumnIndex != gridView.Columns["cFlag"].Index || e.RowIndex < 0)
        return;
        
      // Do your stuff here.
    }
