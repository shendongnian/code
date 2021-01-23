       void Repeater1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
       {
          // Execute the following logic for Items and Alternating Items.
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
          {
             var dataItem = (YourDataItem)e.Item.DataItem;
             if (null == dataItem.Item2)// this is pseudo code because I don't know what your dataItem looks like 
             {
                 ((literal)e.Item.FindControl("Literal2")).Visible = false;
             }
          }
       }    
