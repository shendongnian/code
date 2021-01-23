    void Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
    {
           if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
       {
             var li = (HtmlControl)e.Item.FindControl("IdOfYourLI");  
             ....
    
        }    
     }
