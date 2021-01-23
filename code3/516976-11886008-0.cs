    void Repeater_ItemCreated(Object Sender, RepeaterItemEventArgs e) 
    {
       var control = (LinkButton)e.Item.FindControl("yourLinkButtonId");
    }
    Or
    void Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
                   
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==     ListItemType.AlternatingItem) 
          {
              var control = (LinkButton)e.Item.FindControl("yourLinkButtonId");
          }
       }   
