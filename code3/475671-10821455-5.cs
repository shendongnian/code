    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e) 
    { 
            
      if (e.Item is GridDataItem) 
      { 
        GridDataItem item = (GridDataItem)e.Item; 
        if (string.IsNullOrEmpty(item["Status"].Text)) 
        { 
          item.BackColor = Color.Red; 
          item["Status"].Text = "Empty";
        } 
      } 
    }
