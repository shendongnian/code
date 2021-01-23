     void Repeater1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)  
     {     
       if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
          {
            int IdToBeDeleted=((Label)e.Item.FindControl("idFieldControl")).Text;     
            Button Btn= (Button)e.Item.FindControl("buttonDelete");     
            Btn.Attributes.Add("onclick","return ConfirmDelete('"+IdToBeDeleted+"')");    
          }
    
     } 
