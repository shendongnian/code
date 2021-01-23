    protected void gvUsers_ItemDataBound(object sender, DataListItemEventArgs e)
       {
           if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
           {
               if (e.Item.DataItem != null)
               {
                   string grade = DataBinder.Eval(e.Item.DataItem, "Grade");
                   if(!string.IsNullOrEmpty(grade)){  
                       RadioButtonList radio = e.Item.FindControl("rblChoices") as RadioButtonList; 
                       radio.Items.FindByValue(grade).Selected = true;
                   }
               }
           }
       }
