    protected void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       switch (e.Item.ItemType)
       {
          case ListItemType.Item:
          case ListItemType.AlternatingItem:
          case ListItemType.SelectedItem:
          case ListItemType.EditItem:
          {
             var source = (ContractControl)e.Item.DataItem;
             var destination = (ContractControl)e.Item.FindControl("contractControl");
             destination.ContractID = source.ContractID;
             destination.TileControl = source.TileControl;
             destination.DetailControl = source.DetailControl;
             break;
          }
       }
    }
