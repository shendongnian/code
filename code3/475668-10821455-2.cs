    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e) 
    { 
            
      if (e.Item is GridDataItem) 
      { 
        GridDataItem item = (GridDataItem)e.Item; 
        if (e.Item.DataItem is DataRowView)
        {
          DataRow rw = ((DataRowView)e.Item.DataItem).Row;
          if (rw.IsNull("Status"))
          { 
            item.BackColor = Color.Red; 
          } 
        }
      } 
    }
 
