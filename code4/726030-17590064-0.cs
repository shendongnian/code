    private void repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
      {
         var item = (YourType)e.Item.DataItem;
         var label = (Label)e.Item.FindControl("Label");
         
         if (!string.IsNullOrEmpty(item.eventnumber))
         {
             label.Text = item.eventnumber;
         }
         else
         {
             label.Text = item.productid + "|" + item.type;
         }
      }
    }  
