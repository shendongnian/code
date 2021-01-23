       void Page_Load(Object Sender, EventArgs e) 
       {
             Repeater1.ItemDataBound += repeater1_ItemDataBound;
             Repeater1.DataSource = [your List<Control> containing controls to add];
             Repeater1.DataBind();
       }
       void Repeater1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
       {
          // Execute the following logic for Items and Alternating Items.
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
          {
             var controlToAdd = (Control)e.Item.DataItem;
             ((PlaceHolder)e.Item.FindControl("PlaceHolder1")).Controls.Add(controlToAdd);
             
          }
       }    
