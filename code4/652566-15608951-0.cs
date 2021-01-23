    private void GridViewSale_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
      {
        if (GridViewSale.CurrentCell.ColumnIndex == 4)//Allow only nums for QTY col.
              {
                  TextBox Qty = e.Control as TextBox;
                  Qty.KeyDown -= OnlyNums_KeyDown;
                  Qty.KeyDown += OnlyNums_KeyDown;
              }
      }
    private void GridViewSale_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         if ((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105))
              {
                  //Do Nothing
              }
              else
              {
                  cancelEdit = true;
                  GridViewSale.CellBeginEdit -= GridViewSale_CellBeginEdit;
                  GridViewSale.CellBeginEdit += GridViewSale_CellBeginEdit;
              }
          }
    private void GridViewSale_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
      {
          if (cancelEdit == true)
          {
              e.Cancel = true;
              cancelEdit = false;
          }
      } 
