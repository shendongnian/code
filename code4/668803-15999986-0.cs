    protected void LV_ItemCreated(object sender, ListViewItemEventArgs e)
    {
      // Retrieve the current item.
       ListViewItem item = e.Item;
    
      // Verify if the item is a data item.
      if (item.ItemType == ListViewItemType.DataItem)
      {
        Label someLabel = (Label)ListView1.Controls[i].FindControl("nItemsId");
        if (someLabel != null)
            someLabel.Text = dt.Rows.Count.ToString();
      }
    }
