    private void grid_CurrentCellDirtyStateChanged( object sender, EventArgs e )
    {
      var grid = sender as DataGridView;
      
      if ( grid.IsCurrentCellDirty && grid.CurrentCell.ColumnIndex == 1 )
         grid.CommitEdit( DataGridViewDataErrorContexts.Commit );
    }
