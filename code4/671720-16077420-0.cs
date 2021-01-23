     void Repeater_Beskeder_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
          // This event is raised for the header, the footer, separators, and items.
          // Execute the following logic for Items and Alternating Items.
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
             Panel Vis_Panel = (Panel)row.FindControl("Panel_Vis_Besked");
            if (Request.QueryString["id"].ToString() == reader["id"])
            {
                Vis_Panel.Visible = true;
            }
          }
       }    
