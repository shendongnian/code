    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
       switch (e.Item.ItemType)
       {
          case ListItemType.Item:
          case ListItemType.AlternatingItem:
          case ListItemType.SelectedItem:
          case ListItemType.EditItem:
          {
             Label lblExp = (Label)e.Item.FindControl("lblExp");
             ...
          }
       }
    }
