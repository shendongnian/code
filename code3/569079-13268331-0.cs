    protected void qtyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
          DropDownList control = (DropDownList)sender;
     
          RepeaterItem rpItem = control.NamingContainer as RepeaterItem;
          if (rpItem != null)
          {
             HiddenField hiddenField = ((HiddenField)rpItem.FindControl("ItemId"));    
          }
    }
