    void OrderGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
    
          // Get the cell that contains the item total.
          TableCell cell = e.Row.Cells[2];
    
          // Get the DataBoundLiteralControl control that contains the 
          // data-bound value.
          DataBoundLiteralControl boundControl = (DataBoundLiteralControl)cell.Controls[0];
    
          // Remove the '$' character so that the type converter works properly.
          String itemTotal = boundControl.Text.Replace("$",  "");
    
          // Add the total for an item (row) to the order total.
          orderTotal += Convert.ToDecimal(itemTotal);
    
        }
    
      }
