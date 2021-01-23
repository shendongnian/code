    protected void UserPostRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
         // This event is raised for the header, the footer, separators, and items.
          // Execute the following logic for Items and Alternating Items
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
          {
             Label label = e.Item.FindControl("TextLabel") as Label;
             string text = label.Text;
          }
    }
