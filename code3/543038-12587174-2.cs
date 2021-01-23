    protected virtual void myGridView_OnRowDataBound(GridViewRowEventArgs e)
    {
         if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
         {
             MyCustomGridRow customRow = (MyCustomGridRow)(e.Item.DataItem);
                
             if (!customRow.isValid)
             {
                 int colCount = myGridView.Columns.Count;
                 e.Item.Cells.Clear();
                 Label lblEmptyMessage = new Label
                 {
                     Text = "Custom message for eempty rows.",
                     CssClass = "ErrLabels"
                 };
                 TableCell newCell = new TableCell
                 {
                     ColumnSpan = colCount
                 };
                 newCell.Controls.Add((Control)lblEmptyMessage);
                 e.Item.Cells.Add(newCell);
             }
         }
    }
    
