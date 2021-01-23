    void Repetarer_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
    {
              if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
              {
                   var control = e.Item.FindControl("CheckBox1") as CheckBox;      
                   string result = control.Text;
                   ..... 
              }
           }    
