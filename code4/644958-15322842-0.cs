    protected void UserPostRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        BlogProfileEntities blogProfile = new BlogProfileEntities();
    
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
          Label label = e.Item.FindControl("TextLabel") as Label;
          string text = label.Text;
        }
    }
